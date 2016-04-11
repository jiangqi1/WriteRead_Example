
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using eDriver_IO;
using System.Threading;
//using NationalInstruments.VisaNS;


namespace SN_Check
{
    public partial class Form1 : Form
    {
        int i2c_addr_pwd = 0xA0;   //FOR some products password entry address is 0xA2, such as sfp1871.
        int comm_frame_pwd = 0x0;

        byte[] BtArr_Set;
        byte[] BtArr_Rd;
        byte[] ByteArr_Error = new byte[200];

        public Form1()
        {
            InitializeComponent();
            Init_Edriver();
        }
      
        private int Init_Edriver()
        {
            string message = "";
            int i = 0;
            i = eDriver_IO.Cls_edriver_msa_dll.Edriver_MSA_Config(out ByteArr_Error, ByteArr_Error.Length);
            message = "Edriver_MSA_config: ";
            ErrorcodeControl(message, i, ByteArr_Error);
            if (i == 1)
            {
                i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Config(out ByteArr_Error, ByteArr_Error.Length);
                message = "Edriver_Mem_Config: ";
                ErrorcodeControl(message, i, ByteArr_Error);
                if (i == 1)
                {
                    i = eDriver_IO.Cls_edriver_security_dll.Edriver_Security_Config(out ByteArr_Error, ByteArr_Error.Length);
                    message = "Edriver_Security_Config: ";
                    ErrorcodeControl(message, i, ByteArr_Error);
                    if (i == 1)
                    {
                        i = eDriver_IO.Cls_edriver_module_setup_dll.Edriver_Module_Setup_Config(out ByteArr_Error,
                            ByteArr_Error.Length);
                        message = "Edriver_Module_Setup_Config: ";
                        ErrorcodeControl(message, i, ByteArr_Error);
                        if (i == 1)
                        {
                            i = eDriver_IO.Cls_eui.Eui_Config(out ByteArr_Error, ByteArr_Error.Length);
                            message = "Edriver_Eui_Config: ";
                            ErrorcodeControl(message, i, ByteArr_Error);
                            if (i == 1)
                            {
                                i = eDriver_IO.Cls_edriverdll.Edriver_Config(out ByteArr_Error, ByteArr_Error.Length);
                                message = "Edriver_Config: ";
                                ErrorcodeControl(message, i, ByteArr_Error);
                                if (i == 1)
                                {
                                    Lb_Connection.Text = " Connected Success!";
                                    Lb_Connection.ForeColor = Color.LimeGreen;                                  
                                }
                                else
                                {
                                    Lb_Connection.Text = "Connected Failed";
                                    Lb_Connection.ForeColor = Color.Red;
                                    //if (ErrorMessage(ByteArr_Error).IndexOf("match", StringComparison.OrdinalIgnoreCase) != -1)
                                    //{
                                    //    Application.Exit();
                                    //}                                   
                                }
                            }
                            else
                            {
                                Lb_Connection.Text = "Connected Failed";
                                Lb_Connection.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            Lb_Connection.Text = "Connected Failed";
                            Lb_Connection.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        Lb_Connection.Text = "Connected Failed";
                        Lb_Connection.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Lb_Connection.Text = "Connected Failed";
                    Lb_Connection.ForeColor = Color.Red;
                }
            }
            else
            {
                Lb_Connection.Text = "Connected Failed";
                Lb_Connection.ForeColor = Color.Red;
            }
            
        
            return i;
        }
        private void ErrorcodeControl(string message, int i, byte[] error)
        {
            if (i != 1)
            {
                MessageBox.Show(message + " " + ErrorMessage(error), "Message",
                      MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private string ErrorMessage(byte[] error)
        {
            int j;
            string message = "";
            for (j = 0; j < error.Length; j++)
            {
                message += char.ConvertFromUtf32(Convert.ToInt32(error[j].ToString()));
                if (message[j] == '\0')
                    break;
            }
            message = message + "  ";//Just for the display reason, add the space character on the end of the message
            return message;
        }


        private void Bt_Write_Click(object sender, EventArgs e)
        {
            if (tb_data.Text.Trim() == "")
            {
                errorProvide.SetError(tb_data, " Data should not be empty!");
                return;
            }
            foreach (char ch in tb_data.Text.Trim())
            {
                if ((ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
                {
                }
                else
                {
                    errorProvide.SetError(tb_data, " Data should be capital letters and digital numbers!!");
                    return;
                }
            }
            int format = Convert.ToInt32(tb_format.Text.Trim());
            int length = Convert.ToInt32(tb_length.Text.Trim());
            string tmp = tb_data.Text.Trim().PadLeft(2 * format, '0');
            if (tmp.Length / 2 != format * length)
            {
                errorProvide.SetError(tb_data, " Data length should be data_format* data_length!!");
                return;
            }
            if(check_input())
                Write_Data();
        }       

        public void Write_Data()
        {           
            int i2c_addr = Convert.ToInt32(tb_dev.Text.Trim(),16);
            int comm_frame = Convert.ToInt32(tb_commframe.Text.Trim(),16);
            int data_addr = Convert.ToInt32(tb_mem.Text.Trim(), 16);
            int data_format = Convert.ToInt32(tb_format.Text.Trim());
            int data_length = Convert.ToInt32(tb_length.Text.Trim());
            int delay = 0;
            int i = 1;

            BtArr_Set = new byte[data_format * data_length];
            tb_data.Text = tb_data.Text.Trim().PadLeft(2 * data_format, '0');

            for (int j = 0; j < BtArr_Set.Length; j++)
            {
                BtArr_Set[j] = Convert.ToByte(Convert.ToInt32(tb_data.Text.Trim().Substring(2 * j, 2), 16));
            }

            if (comm_frame == 0xA0)  //access internal
            {
                i = eDriver_IO.Cls_edriver_security_dll.Edriver_Finisar_Password_EN(i2c_addr_pwd,
                    comm_frame_pwd, out ByteArr_Error, ByteArr_Error.Length);
                ErrorcodeControl("Load Password:", i, ByteArr_Error);
            }
            if (i == 1)
            {
                i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(i2c_addr,
                    comm_frame, data_addr, data_length, data_format, BtArr_Set.Length * 8 - 1,
                        BtArr_Set.Length * 8, delay, BtArr_Set, out ByteArr_Error, ByteArr_Error.Length);
                ErrorcodeControl("Write Info", i, ByteArr_Error);
                if (i == 1)
                {
                    rtb_info.AppendText("\n Write Done!");
                }
                else
                {
                    rtb_info.AppendText("\n Write Fail!");
                }
            }
            else
            {
                rtb_info.AppendText("\n Write Fail!");
            }
        }

        private void Bt_Rd_Click(object sender, EventArgs e)
        {
            if(check_input())
                Rd_Data();

        }
        public void Rd_Data()
        {
            int i2c_addr = Convert.ToInt32(tb_dev.Text.Trim(),16);
            int comm_frame =   Convert.ToInt32(tb_commframe.Text.Trim(),16);
            int data_addr = Convert.ToInt32(tb_mem.Text.Trim(), 16);
            int data_format = Convert.ToInt32(tb_format.Text.Trim());
            int data_length = Convert.ToInt32(tb_length.Text.Trim());
            int delay = 0;
            BtArr_Rd = new byte[data_length * data_format];

            int i = 1;
            if (comm_frame == 0xA0)  //hci
            {
                i = eDriver_IO.Cls_edriver_security_dll.Edriver_Finisar_Password_EN(i2c_addr_pwd,
                    comm_frame_pwd, out ByteArr_Error, ByteArr_Error.Length);
                ErrorcodeControl("Load Password:", i, ByteArr_Error);
            }
            if (i == 1)
            {                 
                i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Read(i2c_addr,
                    comm_frame, data_addr, data_length, data_format, BtArr_Rd.Length * 8 - 1,
                    BtArr_Rd.Length * 8, delay, out BtArr_Rd, BtArr_Rd.Length,
                    out ByteArr_Error, ByteArr_Error.Length);
                ErrorcodeControl("Read Info", i, ByteArr_Error);                    
                if (i == 1)
                {
                    string temp = "";
                    for (int j = 0; j < BtArr_Rd.Length; j++)
                    {
                        temp += BtArr_Rd[j].ToString("X2");
                    }                     
                    rtb_info.AppendText("\n" + temp);
                        
                }
                else
                {
                    rtb_info.AppendText("\n Read Failed!");
                }
            }

        }

        private bool check_input()
        {
            if (tb_dev.Text.Trim() == "")
            {
                errorProvide.SetError(tb_dev, " Data should not be empty!");
                return false;
            }
            if (tb_mem.Text.Trim() == "")
            {
                errorProvide.SetError(tb_mem, " Data should not be empty!");
                return false;
            }
            if (tb_commframe.Text.Trim() == "" || ( Convert.ToInt32(tb_commframe.Text.Trim(),16) != 0 && Convert.ToInt32(tb_commframe.Text.Trim(),16) != 160))
            {
                errorProvide.SetError(tb_commframe, " Commframe should be 0 for access MSA or A0 for access Internal table");
                return false;
            }
            if (tb_format.Text.Trim() == "" || Convert.ToInt32(tb_format.Text.Trim(), 16) <= 0 || Convert.ToInt32(tb_format.Text.Trim(), 16) >= 3)
            {
                errorProvide.SetError(tb_format, "Data format should be set to 1 for byte format or 2 for word format!");
                return false;
            }
            if (tb_length.Text.Trim() == "")
            {
                errorProvide.SetError(tb_length, " Data should not be empty!");
                return false;
            }

            return true;
        }

        private void Bt_Connection_Click(object sender, EventArgs e)
        {
            Init_Edriver();
        }
        private void Bt_Clr_Click(object sender, EventArgs e)
        {
            rtb_info.Text = "";
        }

        private void tb_commframe_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_commframe, "Set 0 for access MSA, Set A0 for access Internal table");
        }

        private void tb_mem_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_mem, "page + offset");
        }

        private void tb_format_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_format, "2-word, 1-byte");
        }

        private void tb_length_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_length, "data length to write or read");
        }

        private void tb_data_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_data, "data to be write");
        }

        private void tb_dev_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_dev, "I2C Address");
        }

        private void Test_Bt_Click(object sender, EventArgs e)
        {
            int i;
            int i2c_addr = 0xA0;
            int comm_frame = 0x0;
            int data_addr_0 = 0x0;
            int data_format_0 = 0x08;
            int data_length_0 = 0x08;
            int delay_0 = 0;
            byte[] BtArr_Rd_0;
            BtArr_Rd_0 = new byte[data_length_0 * data_format_0];
            byte[] ByteArr_Error_0 = new byte[200];
            byte[] BtArr_Set = {7,6,5,4,3,2,1,0};

            // test write functon
            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(i2c_addr,
                                                                comm_frame, 
                                                                data_addr_0, 
                                                                data_length_0, 
                                                                data_format_0, 
                                                                2 * 8 - 1,
                                                                2 * 8, 
                                                                delay_0, 
                                                                BtArr_Set, 
                                                                out ByteArr_Error_0,
                                                                200);

            // test read functon
            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Read(i2c_addr,
                                                                comm_frame,
                                                                data_addr_0,
                                                                data_length_0,
                                                                data_format_0,
                                                                2 * 8 - 1,
                                                                BtArr_Rd_0.Length * 8,
                                                                delay_0,
                                                                out BtArr_Rd_0,
                                                                BtArr_Rd_0.Length,
                                                                out ByteArr_Error_0,
                                                                200);
            

        }
    }
}
