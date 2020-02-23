namespace Simple_Switcher
{
    partial class simple_Switcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(simple_Switcher));
            this.take_Button = new System.Windows.Forms.Button();
            this.src_Section = new System.Windows.Forms.GroupBox();
            this.src_Name = new System.Windows.Forms.MaskedTextBox();
            this.src_NameLabel = new System.Windows.Forms.Label();
            this.src_Del = new System.Windows.Forms.Button();
            this.src_Add = new System.Windows.Forms.Button();
            this.src_listBox = new System.Windows.Forms.ListBox();
            this.src_PortNum = new System.Windows.Forms.MaskedTextBox();
            this.src_IPAddr = new System.Windows.Forms.MaskedTextBox();
            this.src_PortLabel = new System.Windows.Forms.Label();
            this.src_IPLabel = new System.Windows.Forms.Label();
            this.dest_PortLabel = new System.Windows.Forms.Label();
            this.dest_IPLabel = new System.Windows.Forms.Label();
            this.dest_Section = new System.Windows.Forms.GroupBox();
            this.dest_Name = new System.Windows.Forms.MaskedTextBox();
            this.dest_NameLabel = new System.Windows.Forms.Label();
            this.dest_Del = new System.Windows.Forms.Button();
            this.dest_Add = new System.Windows.Forms.Button();
            this.dest_listBox = new System.Windows.Forms.ListBox();
            this.dest_PortNum = new System.Windows.Forms.MaskedTextBox();
            this.dest_IPAddr = new System.Windows.Forms.MaskedTextBox();
            this.src_Section.SuspendLayout();
            this.dest_Section.SuspendLayout();
            this.SuspendLayout();
            // 
            // take_Button
            // 
            this.take_Button.BackgroundImage = global::Simple_Switcher.Properties.Resources.take;
            this.take_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.take_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.take_Button.Location = new System.Drawing.Point(273, 96);
            this.take_Button.Name = "take_Button";
            this.take_Button.Size = new System.Drawing.Size(77, 53);
            this.take_Button.TabIndex = 2;
            this.take_Button.UseVisualStyleBackColor = true;
            this.take_Button.Click += new System.EventHandler(this.take_Button_Click);
            // 
            // src_Section
            // 
            this.src_Section.Controls.Add(this.src_Name);
            this.src_Section.Controls.Add(this.src_NameLabel);
            this.src_Section.Controls.Add(this.src_Del);
            this.src_Section.Controls.Add(this.src_Add);
            this.src_Section.Controls.Add(this.src_listBox);
            this.src_Section.Controls.Add(this.src_PortNum);
            this.src_Section.Controls.Add(this.src_IPAddr);
            this.src_Section.Controls.Add(this.src_PortLabel);
            this.src_Section.Controls.Add(this.src_IPLabel);
            this.src_Section.Location = new System.Drawing.Point(8, 4);
            this.src_Section.Name = "src_Section";
            this.src_Section.Size = new System.Drawing.Size(259, 274);
            this.src_Section.TabIndex = 3;
            this.src_Section.TabStop = false;
            this.src_Section.Text = "Source";
            // 
            // src_Name
            // 
            this.src_Name.Location = new System.Drawing.Point(80, 192);
            this.src_Name.Name = "src_Name";
            this.src_Name.Size = new System.Drawing.Size(161, 20);
            this.src_Name.TabIndex = 16;
            this.src_Name.TextChanged += new System.EventHandler(this.src_Name_TextChanged);
            // 
            // src_NameLabel
            // 
            this.src_NameLabel.AutoSize = true;
            this.src_NameLabel.Location = new System.Drawing.Point(16, 192);
            this.src_NameLabel.Name = "src_NameLabel";
            this.src_NameLabel.Size = new System.Drawing.Size(35, 13);
            this.src_NameLabel.TabIndex = 15;
            this.src_NameLabel.Text = "Name";
            // 
            // src_Del
            // 
            this.src_Del.Location = new System.Drawing.Point(166, 151);
            this.src_Del.Name = "src_Del";
            this.src_Del.Size = new System.Drawing.Size(75, 23);
            this.src_Del.TabIndex = 14;
            this.src_Del.Text = "Delete";
            this.src_Del.UseVisualStyleBackColor = true;
            this.src_Del.Click += new System.EventHandler(this.src_Del_Click);
            // 
            // src_Add
            // 
            this.src_Add.Location = new System.Drawing.Point(19, 151);
            this.src_Add.Name = "src_Add";
            this.src_Add.Size = new System.Drawing.Size(75, 23);
            this.src_Add.TabIndex = 12;
            this.src_Add.Text = "Add";
            this.src_Add.UseVisualStyleBackColor = true;
            this.src_Add.Click += new System.EventHandler(this.src_Add_Click);
            // 
            // src_listBox
            // 
            this.src_listBox.FormattingEnabled = true;
            this.src_listBox.Location = new System.Drawing.Point(19, 24);
            this.src_listBox.Name = "src_listBox";
            this.src_listBox.Size = new System.Drawing.Size(222, 121);
            this.src_listBox.TabIndex = 11;
            this.src_listBox.SelectedIndexChanged += new System.EventHandler(this.src_listBox_SelectedValueChanged);
            // 
            // src_PortNum
            // 
            this.src_PortNum.Location = new System.Drawing.Point(80, 244);
            this.src_PortNum.Mask = "00000";
            this.src_PortNum.Name = "src_PortNum";
            this.src_PortNum.Size = new System.Drawing.Size(69, 20);
            this.src_PortNum.TabIndex = 10;
            this.src_PortNum.TextChanged += new System.EventHandler(this.src_PortNum_TextChanged);
            // 
            // src_IPAddr
            // 
            this.src_IPAddr.Location = new System.Drawing.Point(80, 218);
            this.src_IPAddr.Name = "src_IPAddr";
            this.src_IPAddr.Size = new System.Drawing.Size(161, 20);
            this.src_IPAddr.TabIndex = 9;
            this.src_IPAddr.TextChanged += new System.EventHandler(this.src_IPAddr_TextChanged);
            // 
            // src_PortLabel
            // 
            this.src_PortLabel.AutoSize = true;
            this.src_PortLabel.Location = new System.Drawing.Point(16, 244);
            this.src_PortLabel.Name = "src_PortLabel";
            this.src_PortLabel.Size = new System.Drawing.Size(26, 13);
            this.src_PortLabel.TabIndex = 4;
            this.src_PortLabel.Text = "Port";
            // 
            // src_IPLabel
            // 
            this.src_IPLabel.AutoSize = true;
            this.src_IPLabel.Location = new System.Drawing.Point(16, 218);
            this.src_IPLabel.Name = "src_IPLabel";
            this.src_IPLabel.Size = new System.Drawing.Size(58, 13);
            this.src_IPLabel.TabIndex = 3;
            this.src_IPLabel.Text = "IP Address";
            // 
            // dest_PortLabel
            // 
            this.dest_PortLabel.AutoSize = true;
            this.dest_PortLabel.Location = new System.Drawing.Point(16, 250);
            this.dest_PortLabel.Name = "dest_PortLabel";
            this.dest_PortLabel.Size = new System.Drawing.Size(26, 13);
            this.dest_PortLabel.TabIndex = 4;
            this.dest_PortLabel.Text = "Port";
            // 
            // dest_IPLabel
            // 
            this.dest_IPLabel.AutoSize = true;
            this.dest_IPLabel.Location = new System.Drawing.Point(16, 224);
            this.dest_IPLabel.Name = "dest_IPLabel";
            this.dest_IPLabel.Size = new System.Drawing.Size(58, 13);
            this.dest_IPLabel.TabIndex = 3;
            this.dest_IPLabel.Text = "IP Address";
            // 
            // dest_Section
            // 
            this.dest_Section.Controls.Add(this.dest_Name);
            this.dest_Section.Controls.Add(this.dest_NameLabel);
            this.dest_Section.Controls.Add(this.dest_Del);
            this.dest_Section.Controls.Add(this.dest_Add);
            this.dest_Section.Controls.Add(this.dest_listBox);
            this.dest_Section.Controls.Add(this.dest_PortNum);
            this.dest_Section.Controls.Add(this.dest_IPAddr);
            this.dest_Section.Controls.Add(this.dest_PortLabel);
            this.dest_Section.Controls.Add(this.dest_IPLabel);
            this.dest_Section.Location = new System.Drawing.Point(356, 1);
            this.dest_Section.Name = "dest_Section";
            this.dest_Section.Size = new System.Drawing.Size(259, 277);
            this.dest_Section.TabIndex = 7;
            this.dest_Section.TabStop = false;
            this.dest_Section.Text = "Destination";
            // 
            // dest_Name
            // 
            this.dest_Name.Location = new System.Drawing.Point(80, 195);
            this.dest_Name.Name = "dest_Name";
            this.dest_Name.Size = new System.Drawing.Size(161, 20);
            this.dest_Name.TabIndex = 18;
            this.dest_Name.TextChanged += new System.EventHandler(this.dest_Name_TextChanged);
            // 
            // dest_NameLabel
            // 
            this.dest_NameLabel.AutoSize = true;
            this.dest_NameLabel.Location = new System.Drawing.Point(16, 195);
            this.dest_NameLabel.Name = "dest_NameLabel";
            this.dest_NameLabel.Size = new System.Drawing.Size(35, 13);
            this.dest_NameLabel.TabIndex = 17;
            this.dest_NameLabel.Text = "Name";
            // 
            // dest_Del
            // 
            this.dest_Del.Location = new System.Drawing.Point(166, 154);
            this.dest_Del.Name = "dest_Del";
            this.dest_Del.Size = new System.Drawing.Size(75, 23);
            this.dest_Del.TabIndex = 15;
            this.dest_Del.Text = "Delete";
            this.dest_Del.UseVisualStyleBackColor = true;
            this.dest_Del.Click += new System.EventHandler(this.dest_Del_Click);
            // 
            // dest_Add
            // 
            this.dest_Add.Location = new System.Drawing.Point(19, 154);
            this.dest_Add.Name = "dest_Add";
            this.dest_Add.Size = new System.Drawing.Size(75, 23);
            this.dest_Add.TabIndex = 13;
            this.dest_Add.Text = "Add";
            this.dest_Add.UseVisualStyleBackColor = true;
            this.dest_Add.Click += new System.EventHandler(this.dest_Add_Click);
            // 
            // dest_listBox
            // 
            this.dest_listBox.FormattingEnabled = true;
            this.dest_listBox.Location = new System.Drawing.Point(19, 27);
            this.dest_listBox.Name = "dest_listBox";
            this.dest_listBox.Size = new System.Drawing.Size(222, 121);
            this.dest_listBox.TabIndex = 12;
            this.dest_listBox.SelectedIndexChanged += new System.EventHandler(this.dest_listBox_SelectedValueChanged);
            // 
            // dest_PortNum
            // 
            this.dest_PortNum.Location = new System.Drawing.Point(80, 247);
            this.dest_PortNum.Mask = "00000";
            this.dest_PortNum.Name = "dest_PortNum";
            this.dest_PortNum.Size = new System.Drawing.Size(69, 20);
            this.dest_PortNum.TabIndex = 8;
            this.dest_PortNum.TextChanged += new System.EventHandler(this.dest_PortNum_TextChanged);
            // 
            // dest_IPAddr
            // 
            this.dest_IPAddr.Location = new System.Drawing.Point(80, 221);
            this.dest_IPAddr.Name = "dest_IPAddr";
            this.dest_IPAddr.Size = new System.Drawing.Size(161, 20);
            this.dest_IPAddr.TabIndex = 7;
            this.dest_IPAddr.TextChanged += new System.EventHandler(this.dest_IPAddr_TextChanged);
            // 
            // simple_Switcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(622, 286);
            this.Controls.Add(this.dest_Section);
            this.Controls.Add(this.src_Section);
            this.Controls.Add(this.take_Button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "simple_Switcher";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRF - Simple Switcher V_1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.simple_Switcher_FormClosing);
            this.src_Section.ResumeLayout(false);
            this.src_Section.PerformLayout();
            this.dest_Section.ResumeLayout(false);
            this.dest_Section.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button take_Button;
        private System.Windows.Forms.GroupBox src_Section;
        private System.Windows.Forms.Label src_PortLabel;
        private System.Windows.Forms.Label src_IPLabel;
        private System.Windows.Forms.Label dest_PortLabel;
        private System.Windows.Forms.Label dest_IPLabel;
        private System.Windows.Forms.GroupBox dest_Section;
        private System.Windows.Forms.MaskedTextBox dest_PortNum;
        private System.Windows.Forms.MaskedTextBox dest_IPAddr;
        private System.Windows.Forms.MaskedTextBox src_PortNum;
        private System.Windows.Forms.MaskedTextBox src_IPAddr;
        private System.Windows.Forms.ListBox src_listBox;
        private System.Windows.Forms.ListBox dest_listBox;
        private System.Windows.Forms.Button src_Del;
        private System.Windows.Forms.Button src_Add;
        private System.Windows.Forms.Button dest_Del;
        private System.Windows.Forms.Button dest_Add;
        private System.Windows.Forms.MaskedTextBox src_Name;
        private System.Windows.Forms.Label src_NameLabel;
        private System.Windows.Forms.MaskedTextBox dest_Name;
        private System.Windows.Forms.Label dest_NameLabel;

    }
}

