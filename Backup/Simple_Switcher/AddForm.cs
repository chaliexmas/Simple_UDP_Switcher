using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Simple_Switcher
{
    public partial class AddForm : Form
    {
        public string add_Name;
        public string add_IP;
        public string add_Port;

        public AddForm()
        {
            InitializeComponent();
        }

        private void add_OkBtn_Click(object sender, EventArgs e)
        {
            //store the values
            add_Name = add_NameBox.Text;

            //check that it is an IP
            add_IP = add_IPBox.Text;

            //check that it is a number
            add_Port = add_PortBox.Text;

            //make sure their not empty
            if (String.IsNullOrEmpty(add_Name) ||
                String.IsNullOrEmpty(add_IP) ||
                String.IsNullOrEmpty(add_Port))
            {
                //warn user
                MessageBox.Show("Do not leave fields blank!");

                if (String.IsNullOrEmpty(add_Port))
                {
                    add_Port = "0";
                }

                //dont do anything
                return;
            }
        }

        private void add_CancelBtn_Click(object sender, EventArgs e)
        {
            //close the window
            this.Close();
        }

        private void add_IPBox_TextChanged(object sender, EventArgs e)
        {
            //check for only numbers and periods
            foreach (char c in add_IPBox.Text)
            {
                if (!Char.IsDigit(c) && !c.Equals('.'))
                {
                    //remove it
                    add_IPBox.Clear();

                    //warn user
                    new ToolTip().Show("Only numbers and periods allowed",
                        add_IPBox, 20, add_IPBox.Height, 3500);
                }
            }//end foreach
        }

        private void add_PortBox_TextChanged(object sender, EventArgs e)
        {
            //check for only numbers
            foreach (char c in add_PortBox.Text)
            {
                if (!Char.IsDigit(c))
                {
                    //remove it
                    add_PortBox.Clear();

                    //warn user
                    new ToolTip().Show("Only numbers allowed",
                        add_PortBox, 20, add_PortBox.Height, 3500);
                }
            }//end foreach
        }//

    }
}