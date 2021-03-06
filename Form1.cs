﻿
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
using System.Reflection;
using ReadWriteCsv;



namespace ReadWrite
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
            WriteTest();
            ReadTest();
            InitializeComponent();
            Init_Edriver();
            ReadMode();
        }

        private void WriteTest()
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter("WriteTest.csv"))
            {
                for (int i = 0; i < 100; i++)
                {
                    CsvRow row = new CsvRow();
                    for (int j = 0; j < 5; j++)
                        row.Add(String.Format("Column{0}", j));
                    writer.WriteRow(row);
                }
            }
        }

        private void ReadTest()
        {
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader("ReadTest.csv"))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    foreach (string s in row)
                    {
                        Console.Write(s);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
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
            if (check_input())
                Write_Data();
        }

        public void Write_Data()
        {
            int i2c_addr = Convert.ToInt32(tb_dev.Text.Trim(), 16);
            int comm_frame = Convert.ToInt32(tb_commframe.Text.Trim(), 16);
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
            if (check_input())
                Rd_Data();

        }
        public void Rd_Data()
        {
            int i2c_addr = Convert.ToInt32(tb_dev.Text.Trim(), 16);
            int comm_frame = Convert.ToInt32(tb_commframe.Text.Trim(), 16);
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
            if (tb_commframe.Text.Trim() == "" || (Convert.ToInt32(tb_commframe.Text.Trim(), 16) != 0 && Convert.ToInt32(tb_commframe.Text.Trim(), 16) != 160))
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

        private string Change_TentoHex2(Byte bytTempData)
        {
            if (bytTempData < 16)
            {
                return "0" + bytTempData.ToString("X").Trim();
            }
            else
            {
                return bytTempData.ToString("X").Trim();
            }
        }

        private void Test_Bt_Click(object sender, EventArgs e)
        {
            int i;
            int i2c_addr = 0xA0;
            int comm_frame = 0x0;
            int data_addr_0 = 0x0;
            int data_format_0 = 0x01;
            int data_length_0 = 0x10;
            int delay_0 = 0;
            byte[] BtArr_Rd_0;
            BtArr_Rd_0 = new byte[data_length_0 * data_format_0];
            byte[] ByteArr_Error_0 = new byte[200];
            byte[] BtArr_Set = { 0xf, 0xe, 0xd, 0xc, 0xb, 0xa, 0x9, 0x8, 0x7, 0x6, 0x5, 0x4, 0x3, 0x2, 0x1, 0 };
            byte[] BtArr_Set_0 = { 0xff, 0xee, 0xdd, 0xcc, 0xbb, 0xaa, 0x99, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0 };

            // Trouble shooting 
            int data_addr_Tx_Dis = 86;   // Tx disable
            int data_addr_TRx_LOL = 5;   // Rx LOL: 3:0, Tx LOL: 7:4 
            int data_length_1 = 0x1;
            byte[] BtArr_Rd_Tx_Dis;
            BtArr_Rd_Tx_Dis = new byte[data_length_1 * data_format_0];
            byte[] BtArr_Rd_TRx_LOL;
            BtArr_Rd_TRx_LOL = new byte[data_length_1 * data_format_0];
            byte[] BtArr_Set_Tx_Dis_05 = { 0x05 };  // 4ch disable
            byte[] BtArr_Set_Tx_Dis_0A = { 0x0A };  // 4ch disable

            byte[] BtArr_Set_Page_Sel = { 0x00 };
            byte[] BtArr_Set_page_TRx_CDR_ByPass = { 0xFF };    // 0, bypass, 1, enable: Tx-7:4 Rx-3:0
            // enable CDR: 1, pagesel 0x03; 2, set cdr enable
            rtb_info.AppendText("\n");
            rtb_info.AppendText("CDR Enable");
            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(0xa0,
                                                                0,
                                                                0x7F,       // page sel
                                                                1,
                                                                1,
                                                                8 - 1,      //this parameter seems
                                                                8,
                                                                0,
                                                                BtArr_Set_Tx_Dis_05,
                                                                out ByteArr_Error_0,
                                                                200);


/*
            // Trouble shooting Rx LOL issue
            int data_addr_Tx_Dis = 86;   // Tx disable
            int data_addr_TRx_LOL = 5;   // Rx LOL: 3:0, Tx LOL: 7:4 
            int data_length_1 = 0x1;
            byte[] BtArr_Rd_Tx_Dis;
            BtArr_Rd_Tx_Dis = new byte[data_length_1 * data_format_0];
            byte[] BtArr_Rd_TRx_LOL;
            BtArr_Rd_TRx_LOL = new byte[data_length_1 * data_format_0];
            byte[] BtArr_Set_Tx_Dis = { 0x0F };  // 4ch disable
            byte[] BtArr_Set_Page_Sel = { 0x03 };
            byte[] BtArr_Set_page_TRx_CDR_ByPass = { 0xFF };    // 0, bypass, 1, enable: Tx-7:4 Rx-3:0
            // enable CDR: 1, pagesel 0x03; 2, set cdr enable
            rtb_info.AppendText("\n");
            rtb_info.AppendText("CDR Enable");
            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(0xa0,
                                                                0,
                                                                0x7F,       // page sel
                                                                1,
                                                                1,
                                                                8 - 1,      //this parameter seems
                                                                8,
                                                                0,
                                                                BtArr_Set_Page_Sel,
                                                                out ByteArr_Error_0,
                                                                200);

            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(0xa0,
                                                                0,
                                                                0x62,       // cdr enable
                                                                1,
                                                                1,
                                                                8 - 1,    //this parameter seems
                                                                8,
                                                                0,
                                                                BtArr_Set_page_TRx_CDR_ByPass,
                                                                out ByteArr_Error_0,
                                                                200);

            // Tx disable ch
                        i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(i2c_addr,
                                                                            comm_frame,
                                                                            data_addr_Tx_Dis,
                                                                            data_length_1,
                                                                            data_format_0,
                                                                            8 - 1,    //this parameter seems
                                                                            8 ,
                                                                            delay_0,
                                                                            BtArr_Set_Tx_Dis,
                                                                            out ByteArr_Error_0,
                                                                            200);

                        i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Read(i2c_addr,
                                                                comm_frame,
                                                                data_addr_Tx_Dis,
                                                                data_length_1,
                                                                data_format_0,
                                                                8  - 1,
                                                                BtArr_Rd_Tx_Dis.Length * 8,
                                                                delay_0,
                                                                out BtArr_Rd_Tx_Dis,
                                                                BtArr_Rd_Tx_Dis.Length,
                                                                out ByteArr_Error_0,
                                                                200);


                        rtb_info.AppendText("\n");
                        rtb_info.AppendText("Tx Disable");
                        rtb_info.AppendText("\nR):\n");
                        for (int j = 0; j < BtArr_Rd_Tx_Dis.Length; j++)
                        {
                            //rtb_info.AppendText(BtArr_Rd_0[j].ToString() + " ");
                            rtb_info.AppendText("0x" + Change_TentoHex2(BtArr_Rd_Tx_Dis[j]) + " ");   // updated and show hex value in textbox
                        }

                        Thread.Sleep(3000); // delay 3000ms
            // Read back Rx LOL state
                        i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Read(i2c_addr,
                                                    comm_frame,
                                                    data_addr_TRx_LOL,
                                                    data_length_1,
                                                    data_format_0,
                                                    8 - 1,
                                                    BtArr_Rd_TRx_LOL.Length * 8,
                                                    delay_0,
                                                    out BtArr_Rd_TRx_LOL,
                                                    BtArr_Rd_TRx_LOL.Length,
                                                    out ByteArr_Error_0,
                                                    200);

                        rtb_info.AppendText("\n");
                        rtb_info.AppendText("Rx LOL 3:0");
                        rtb_info.AppendText("\nR):\n");
                        for (int j = 0; j < BtArr_Rd_TRx_LOL.Length; j++)
                        {
                            //rtb_info.AppendText(BtArr_Rd_0[j].ToString() + " ");
                            rtb_info.AppendText("0x" + Change_TentoHex2(BtArr_Rd_TRx_LOL[j]) + " ");   // updated and show hex value in textbox
                        }
/*

/*
                        BtArr_Set_Tx_Dis[0] = 0;  // 4ch enable
                        i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(i2c_addr,
                                                                            comm_frame,
                                                                            data_addr_Tx_Dis,
                                                                            data_length_1,
                                                                            data_format_0,
                                                                            8 - 1,    //this parameter seems
                                                                            8 ,
                                                                            delay_0,
                                                                            BtArr_Set_Tx_Dis,
                                                                            out ByteArr_Error_0,
                                                                            200);
/*
            // ------------------------  start: write and read back MSA field functon ----------------------------------------------//
            rtb_info.AppendText("\nW):\n");
            //rtb_info.AppendText("Write and Read on MSA filed: 0x00 to 0xF\n");
            for (int j = 0; j < BtArr_Set.Length; j++)
            {
                //rtb_info.AppendText("0x" + BtArr_Set[j].ToString() + " ");        // orignal code
                rtb_info.AppendText("0x" + Change_TentoHex2(BtArr_Set[j]) + " ");   // updated and show hex value in textbox
            }

            //SetMode(true);  // set the mode, which depend on the .ini file
            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(i2c_addr,
                                                                comm_frame,
                                                                data_addr_0,
                                                                data_length_0,
                                                                data_format_0,
                                                                8 * 8 - 1,
                                                                8 * 8,
                                                                delay_0,
                                                                BtArr_Set,
                                                                out ByteArr_Error_0,
                                                                200);

            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Read(i2c_addr,
                                                                comm_frame,
                                                                data_addr_0,
                                                                data_length_0,
                                                                data_format_0,
                                                                8* 8 - 1,
                                                                BtArr_Rd_0.Length * 8,
                                                                delay_0,
                                                                out BtArr_Rd_0,
                                                                BtArr_Rd_0.Length,
                                                                out ByteArr_Error_0,
                                                                200);


            rtb_info.AppendText("\nR):\n");
            for(int j=0; j<BtArr_Rd_0.Length;j++)
            {
                //rtb_info.AppendText(BtArr_Rd_0[j].ToString() + " ");
                rtb_info.AppendText("0x" + Change_TentoHex2(BtArr_Rd_0[j]) + " ");   // updated and show hex value in textbox
            }
            // ------------------------  start: end and read back MSA field functon ----------------------------------------------//

            // ------------------------  start: write and read back HCI field functon ----------------------------------------------//
            i2c_addr = 0xA0;
            comm_frame = 0xA0;
            data_addr_0 = 0x4000;
            data_format_0 = 0x02;
            delay_0 = 0;
            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Write(i2c_addr,
                                                                comm_frame,
                                                                data_addr_0,
                                                                data_length_0,
                                                                data_format_0,
                                                                16 * 8 - 1,     // word orient 
                                                                16 * 8,         // word orient
                                                                delay_0,
                                                                BtArr_Set_0,
                                                                out ByteArr_Error_0,
                                                                200);
            rtb_info.AppendText("\nW):\n");
            for (int j = 0; j < BtArr_Set.Length; j++)
            {
                //rtb_info.AppendText("0x" + BtArr_Set[j].ToString() + " ");        // orignal code
                rtb_info.AppendText("0x" + Change_TentoHex2(BtArr_Set_0[j]) + " ");   // updated and show hex value in textbox
            }

            i = eDriver_IO.Cls_edriver_mem_dll.Edriver_Mem_Read(i2c_addr,
                                                    comm_frame,
                                                    data_addr_0,
                                                    data_length_0,
                                                    data_format_0,
                                                    8 * 8 - 1,
                                                    BtArr_Rd_0.Length * 8,  
                                                    delay_0,
                                                    out BtArr_Rd_0,
                                                    BtArr_Rd_0.Length,
                                                    out ByteArr_Error_0,
                                                    200);
            rtb_info.AppendText("\nR):\n");
            for (int j = 0; j < BtArr_Rd_0.Length; j++)
            {
                //rtb_info.AppendText(BtArr_Rd_0[j].ToString() + " ");
                rtb_info.AppendText("0x" + Change_TentoHex2(BtArr_Rd_0[j]) + " ");   // updated and show hex value in textbox
            }


            // ------------------------  end: write and read back HCI field functon ----------------------------------------------//

*/
        }






        #region  enable/disable simulation
        private void btn_simulation_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (this.Text.Contains("( Simulation Mode )"))
            {
                this.Text = "Read Write Example";
                SetMode(false);
            }
            else
            {
                this.Text = "Read Write Example ( Simulation Mode )";
                SetMode(true);
            }

            Init_Edriver();
            ReadMode();
        }
        private void ReadMode()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\edriver_user.ini";
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader read = new StreamReader(fs);
                read.BaseStream.Seek(0, SeekOrigin.Begin);
                while (read.Peek() > -1)
                {
                    string readconfig = read.ReadLine().Trim();
                    if (readconfig.IndexOf("SIMULATION") != -1)
                    {
                        string temp = readconfig.Split('#')[0].Split('=')[1].Trim();
                        if (temp == "ENABLE")
                        {
                            btn_simulation.Text = "Simulation (OFF)";
                        }
                        else
                        {
                            btn_simulation.Text = "Simulation (ON)";
                        }
                    }
                }
                read.Close();
                fs.Close();
            }
            else
            {
                MessageBox.Show(path + "can not be loaded," + "\r\n" +
                           "please check if it does not exist or is used by other program.", "Warning",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SetMode(bool value)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\edriver_user.ini";
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader read = new StreamReader(fs);
                StreamWriter write = new StreamWriter(fs);
                string str = read.ReadToEnd();
                if (value)
                {
                    str = str.Replace("SIMULATION= BYPASS", "SIMULATION= ENABLE");
                    str = str.TrimEnd('\n').TrimEnd('\r');

                }
                else
                {
                    str = str.Replace("SIMULATION= ENABLE", "SIMULATION= BYPASS");
                    str = str.TrimEnd('\n').TrimEnd('\r');
                }
                fs.SetLength(0);
                write.WriteLine(str);
                write.Flush();
                write.Close();
                fs.Close();
            }
            else
            {
                MessageBox.Show(path + "can not be loaded," + "\r\n" +
                           "please check if it does not exist or is used by other program.", "Warning",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
