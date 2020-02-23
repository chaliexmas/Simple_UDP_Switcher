namespace Simple_Switcher
{
    partial class AddForm
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
            this.add_OkBtn = new System.Windows.Forms.Button();
            this.add_CancelBtn = new System.Windows.Forms.Button();
            this.add_NameLabel = new System.Windows.Forms.Label();
            this.add_IPLabel = new System.Windows.Forms.Label();
            this.add_PortLabel = new System.Windows.Forms.Label();
            this.add_NameBox = new System.Windows.Forms.TextBox();
            this.add_IPBox = new System.Windows.Forms.TextBox();
            this.add_PortBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add_OkBtn
            // 
            this.add_OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.add_OkBtn.Location = new System.Drawing.Point(9, 131);
            this.add_OkBtn.Name = "add_OkBtn";
            this.add_OkBtn.Size = new System.Drawing.Size(61, 23);
            this.add_OkBtn.TabIndex = 0;
            this.add_OkBtn.Text = "Ok";
            this.add_OkBtn.UseVisualStyleBackColor = true;
            this.add_OkBtn.Click += new System.EventHandler(this.add_OkBtn_Click);
            // 
            // add_CancelBtn
            // 
            this.add_CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.add_CancelBtn.Location = new System.Drawing.Point(86, 131);
            this.add_CancelBtn.Name = "add_CancelBtn";
            this.add_CancelBtn.Size = new System.Drawing.Size(61, 23);
            this.add_CancelBtn.TabIndex = 1;
            this.add_CancelBtn.Text = "Cancel";
            this.add_CancelBtn.UseVisualStyleBackColor = true;
            this.add_CancelBtn.Click += new System.EventHandler(this.add_CancelBtn_Click);
            // 
            // add_NameLabel
            // 
            this.add_NameLabel.AutoSize = true;
            this.add_NameLabel.Location = new System.Drawing.Point(6, 31);
            this.add_NameLabel.Name = "add_NameLabel";
            this.add_NameLabel.Size = new System.Drawing.Size(35, 13);
            this.add_NameLabel.TabIndex = 2;
            this.add_NameLabel.Text = "Name";
            // 
            // add_IPLabel
            // 
            this.add_IPLabel.AutoSize = true;
            this.add_IPLabel.Location = new System.Drawing.Point(6, 64);
            this.add_IPLabel.Name = "add_IPLabel";
            this.add_IPLabel.Size = new System.Drawing.Size(17, 13);
            this.add_IPLabel.TabIndex = 3;
            this.add_IPLabel.Text = "IP";
            // 
            // add_PortLabel
            // 
            this.add_PortLabel.AutoSize = true;
            this.add_PortLabel.Location = new System.Drawing.Point(6, 97);
            this.add_PortLabel.Name = "add_PortLabel";
            this.add_PortLabel.Size = new System.Drawing.Size(26, 13);
            this.add_PortLabel.TabIndex = 4;
            this.add_PortLabel.Text = "Port";
            // 
            // add_NameBox
            // 
            this.add_NameBox.Location = new System.Drawing.Point(47, 28);
            this.add_NameBox.Name = "add_NameBox";
            this.add_NameBox.Size = new System.Drawing.Size(100, 20);
            this.add_NameBox.TabIndex = 5;
            // 
            // add_IPBox
            // 
            this.add_IPBox.Location = new System.Drawing.Point(47, 61);
            this.add_IPBox.Name = "add_IPBox";
            this.add_IPBox.Size = new System.Drawing.Size(100, 20);
            this.add_IPBox.TabIndex = 6;
            this.add_IPBox.TextChanged += new System.EventHandler(this.add_IPBox_TextChanged);
            // 
            // add_PortBox
            // 
            this.add_PortBox.Location = new System.Drawing.Point(47, 94);
            this.add_PortBox.Name = "add_PortBox";
            this.add_PortBox.Size = new System.Drawing.Size(100, 20);
            this.add_PortBox.TabIndex = 7;
            this.add_PortBox.TextChanged += new System.EventHandler(this.add_PortBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.add_NameBox);
            this.groupBox1.Controls.Add(this.add_OkBtn);
            this.groupBox1.Controls.Add(this.add_CancelBtn);
            this.groupBox1.Controls.Add(this.add_PortBox);
            this.groupBox1.Controls.Add(this.add_NameLabel);
            this.groupBox1.Controls.Add(this.add_IPBox);
            this.groupBox1.Controls.Add(this.add_IPLabel);
            this.groupBox1.Controls.Add(this.add_PortLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 164);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(185, 190);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Channel";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_OkBtn;
        private System.Windows.Forms.Button add_CancelBtn;
        private System.Windows.Forms.Label add_NameLabel;
        private System.Windows.Forms.Label add_IPLabel;
        private System.Windows.Forms.Label add_PortLabel;
        private System.Windows.Forms.TextBox add_NameBox;
        private System.Windows.Forms.TextBox add_IPBox;
        private System.Windows.Forms.TextBox add_PortBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}