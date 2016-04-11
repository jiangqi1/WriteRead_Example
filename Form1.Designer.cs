namespace ReadWrite
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Bt_St = new System.Windows.Forms.Button();
            this.Bt_Connection = new System.Windows.Forms.Button();
            this.Lb_Connection = new System.Windows.Forms.Label();
            this.Bt_Clr = new System.Windows.Forms.Button();
            this.Bt_Rd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_dev = new System.Windows.Forms.TextBox();
            this.tb_mem = new System.Windows.Forms.TextBox();
            this.rtb_info = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_length = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_commframe = new System.Windows.Forms.Label();
            this.tb_commframe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_format = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_data = new System.Windows.Forms.TextBox();
            this.errorProvide = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Test_Bt = new System.Windows.Forms.Button();
            this.btn_simulation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvide)).BeginInit();
            this.SuspendLayout();
            // 
            // Bt_St
            // 
            this.Bt_St.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_St.BackColor = System.Drawing.Color.White;
            this.Bt_St.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_St.Location = new System.Drawing.Point(298, 353);
            this.Bt_St.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_St.Name = "Bt_St";
            this.Bt_St.Size = new System.Drawing.Size(77, 25);
            this.Bt_St.TabIndex = 15;
            this.Bt_St.Text = "Write";
            this.Bt_St.UseVisualStyleBackColor = false;
            this.Bt_St.Click += new System.EventHandler(this.Bt_Write_Click);
            // 
            // Bt_Connection
            // 
            this.Bt_Connection.BackColor = System.Drawing.Color.White;
            this.Bt_Connection.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Connection.Location = new System.Drawing.Point(2, 2);
            this.Bt_Connection.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Connection.Name = "Bt_Connection";
            this.Bt_Connection.Size = new System.Drawing.Size(129, 25);
            this.Bt_Connection.TabIndex = 19;
            this.Bt_Connection.Text = "Verify Connection";
            this.Bt_Connection.UseVisualStyleBackColor = false;
            this.Bt_Connection.Click += new System.EventHandler(this.Bt_Connection_Click);
            // 
            // Lb_Connection
            // 
            this.Lb_Connection.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Connection.Location = new System.Drawing.Point(136, 6);
            this.Lb_Connection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Connection.Name = "Lb_Connection";
            this.Lb_Connection.Size = new System.Drawing.Size(173, 14);
            this.Lb_Connection.TabIndex = 20;
            this.Lb_Connection.Text = "Connection Status:";
            this.Lb_Connection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bt_Clr
            // 
            this.Bt_Clr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Clr.BackColor = System.Drawing.Color.White;
            this.Bt_Clr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Clr.Location = new System.Drawing.Point(140, 353);
            this.Bt_Clr.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Clr.Name = "Bt_Clr";
            this.Bt_Clr.Size = new System.Drawing.Size(71, 25);
            this.Bt_Clr.TabIndex = 21;
            this.Bt_Clr.Text = "Clear";
            this.Bt_Clr.UseVisualStyleBackColor = false;
            this.Bt_Clr.Click += new System.EventHandler(this.Bt_Clr_Click);
            // 
            // Bt_Rd
            // 
            this.Bt_Rd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Rd.BackColor = System.Drawing.Color.White;
            this.Bt_Rd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Rd.Location = new System.Drawing.Point(219, 353);
            this.Bt_Rd.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Rd.Name = "Bt_Rd";
            this.Bt_Rd.Size = new System.Drawing.Size(71, 25);
            this.Bt_Rd.TabIndex = 23;
            this.Bt_Rd.Text = "Read";
            this.Bt_Rd.UseVisualStyleBackColor = false;
            this.Bt_Rd.Click += new System.EventHandler(this.Bt_Rd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Memory Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Device Address";
            // 
            // tb_dev
            // 
            this.tb_dev.Location = new System.Drawing.Point(37, 39);
            this.tb_dev.Name = "tb_dev";
            this.tb_dev.Size = new System.Drawing.Size(85, 22);
            this.tb_dev.TabIndex = 25;
            this.tb_dev.Text = "A0";
            this.tb_dev.MouseEnter += new System.EventHandler(this.tb_dev_MouseEnter);
            // 
            // tb_mem
            // 
            this.tb_mem.Location = new System.Drawing.Point(39, 90);
            this.tb_mem.Name = "tb_mem";
            this.tb_mem.Size = new System.Drawing.Size(83, 22);
            this.tb_mem.TabIndex = 25;
            this.tb_mem.Text = "0000";
            this.tb_mem.MouseEnter += new System.EventHandler(this.tb_mem_MouseEnter);
            // 
            // rtb_info
            // 
            this.rtb_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_info.Location = new System.Drawing.Point(6, 34);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.Size = new System.Drawing.Size(336, 312);
            this.rtb_info.TabIndex = 26;
            this.rtb_info.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Data length";
            // 
            // tb_length
            // 
            this.tb_length.Location = new System.Drawing.Point(38, 236);
            this.tb_length.Name = "tb_length";
            this.tb_length.Size = new System.Drawing.Size(84, 22);
            this.tb_length.TabIndex = 25;
            this.tb_length.Text = "1";
            this.tb_length.MouseEnter += new System.EventHandler(this.tb_length_MouseEnter);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "0x";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "0x";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 236);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "0x";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_commframe
            // 
            this.lb_commframe.AutoSize = true;
            this.lb_commframe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_commframe.Location = new System.Drawing.Point(17, 120);
            this.lb_commframe.Name = "lb_commframe";
            this.lb_commframe.Size = new System.Drawing.Size(88, 16);
            this.lb_commframe.TabIndex = 24;
            this.lb_commframe.Text = "Comm_frame";
            // 
            // tb_commframe
            // 
            this.tb_commframe.Location = new System.Drawing.Point(39, 139);
            this.tb_commframe.Name = "tb_commframe";
            this.tb_commframe.Size = new System.Drawing.Size(83, 22);
            this.tb_commframe.TabIndex = 25;
            this.tb_commframe.Text = "0";
            this.tb_commframe.MouseEnter += new System.EventHandler(this.tb_commframe_MouseEnter);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "0x";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Data format";
            // 
            // tb_format
            // 
            this.tb_format.Location = new System.Drawing.Point(39, 189);
            this.tb_format.Name = "tb_format";
            this.tb_format.Size = new System.Drawing.Size(83, 22);
            this.tb_format.TabIndex = 25;
            this.tb_format.Text = "1";
            this.tb_format.MouseEnter += new System.EventHandler(this.tb_format_MouseEnter);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 190);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 18);
            this.label10.TabIndex = 28;
            this.label10.Text = "0x";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lb_commframe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_format);
            this.groupBox1.Controls.Add(this.tb_dev);
            this.groupBox1.Controls.Add(this.tb_commframe);
            this.groupBox1.Controls.Add(this.tb_data);
            this.groupBox1.Controls.Add(this.tb_mem);
            this.groupBox1.Controls.Add(this.tb_length);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(348, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 320);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Parameters ";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 287);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 18);
            this.label11.TabIndex = 28;
            this.label11.Text = "0x";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Write Data ";
            // 
            // tb_data
            // 
            this.tb_data.Location = new System.Drawing.Point(39, 287);
            this.tb_data.Name = "tb_data";
            this.tb_data.Size = new System.Drawing.Size(84, 22);
            this.tb_data.TabIndex = 25;
            this.tb_data.Text = "00";
            this.tb_data.MouseEnter += new System.EventHandler(this.tb_data_MouseEnter);
            // 
            // errorProvide
            // 
            this.errorProvide.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // Test_Bt
            // 
            this.Test_Bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Test_Bt.BackColor = System.Drawing.Color.White;
            this.Test_Bt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Test_Bt.Location = new System.Drawing.Point(6, 352);
            this.Test_Bt.Margin = new System.Windows.Forms.Padding(4);
            this.Test_Bt.Name = "Test_Bt";
            this.Test_Bt.Size = new System.Drawing.Size(114, 25);
            this.Test_Bt.TabIndex = 31;
            this.Test_Bt.Text = "Test";
            this.Test_Bt.UseVisualStyleBackColor = false;
            this.Test_Bt.Click += new System.EventHandler(this.Test_Bt_Click);
            // 
            // btn_simulation
            // 
            this.btn_simulation.Location = new System.Drawing.Point(385, 355);
            this.btn_simulation.Name = "btn_simulation";
            this.btn_simulation.Size = new System.Drawing.Size(109, 23);
            this.btn_simulation.TabIndex = 32;
            this.btn_simulation.Text = "Enable Simulation";
            this.btn_simulation.UseVisualStyleBackColor = true;
            this.btn_simulation.Click += new System.EventHandler(this.btn_simulation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(506, 380);
            this.Controls.Add(this.btn_simulation);
            this.Controls.Add(this.Test_Bt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtb_info);
            this.Controls.Add(this.Bt_Rd);
            this.Controls.Add(this.Bt_Clr);
            this.Controls.Add(this.Lb_Connection);
            this.Controls.Add(this.Bt_Connection);
            this.Controls.Add(this.Bt_St);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Read Write Example";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bt_St;
        private System.Windows.Forms.Button Bt_Connection;
        private System.Windows.Forms.Label Lb_Connection;
        private System.Windows.Forms.Button Bt_Clr;
        private System.Windows.Forms.Button Bt_Rd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_dev;
        private System.Windows.Forms.TextBox tb_mem;
        private System.Windows.Forms.RichTextBox rtb_info;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_commframe;
        private System.Windows.Forms.TextBox tb_commframe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_format;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvide;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_data;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Test_Bt;
        private System.Windows.Forms.Button btn_simulation;
    }
}

