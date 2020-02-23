using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Simple_Switcher
{
    public partial class simple_Switcher : Form
    {
        Channels_Manager ch_mngr;
        Connections_Manager cn_mngr;

        /// <summary>
        /// The constructor access the data available from the channels manager
        /// and populates the GUI
        /// </summary>
        public simple_Switcher()
        {
            //show a splash screen on  window load
            Thread splash = new Thread(new ThreadStart(showSplash));
            splash.Start();
            Thread.Sleep(1250);
            splash.Abort();
            Thread.Sleep(100);

            InitializeComponent();

            //initialize channel data
            ch_mngr = new Channels_Manager();

            //
            cn_mngr = new Connections_Manager();

            //add channel names to listbox
            for (int i = 0; i < ch_mngr.number_of_Src_Channels; i++)
            {
                src_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Sources", i, 0));
            }

            for (int i = 0; i < ch_mngr.number_of_Dest_Channels; i++)
            {
                dest_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Destinations", i, 0));
            }

            //set the first channels as visible
            if (src_listBox.Items.Count > 0 && dest_listBox.Items.Count > 0)
            {
                src_listBox.SelectedIndex = 0;
                dest_listBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void refresh_ListBoxes()
        {
            //get the currently selected ant store it
            int src_sel = src_listBox.SelectedIndex;
            int dest_sel = dest_listBox.SelectedIndex;

            //remove all items
            src_listBox.Items.Clear();
            dest_listBox.Items.Clear();

            //re-add all items
            //add channel names to listbox
            for (int i = 0; i < ch_mngr.number_of_Src_Channels; i++)
            {
                src_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Sources", i, 0));
            }

            for (int i = 0; i < ch_mngr.number_of_Dest_Channels; i++)
            {
                dest_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Destinations", i, 0));
            }
            
            //set the selected to previously selected
            if (src_sel > -1 || dest_sel > -1)
            {
                src_listBox.SelectedIndex = src_sel;
                dest_listBox.SelectedIndex = dest_sel;
            }
            else
            {
                dest_listBox.SelectedIndex = 0;
                src_listBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// change the icon to match the connection
        /// </summary>
        public void adjust_Button()
        {
            if ((!String.IsNullOrEmpty(dest_PortNum.Text) && !String.IsNullOrEmpty(src_PortNum.Text)) 
                 && cn_mngr.Is_Connected(src_IPAddr.Text, Convert.ToInt32(src_PortNum.Text), 
                dest_IPAddr.Text, Convert.ToInt32(dest_PortNum.Text)))
            {
                //update button image
                take_Button.BackgroundImage = global::Simple_Switcher.Properties.Resources.stop_Z;

                //also make fields not editable
                src_IPAddr.ReadOnly = true;
                dest_IPAddr.ReadOnly = true;
                src_Name.ReadOnly = true;
                dest_Name.ReadOnly = true;
                src_PortNum.ReadOnly = true;
                dest_PortNum.ReadOnly = true;
            }
            else
            {
                //update button image
                take_Button.BackgroundImage = global::Simple_Switcher.Properties.Resources.take;

                //make fields editable
                src_IPAddr.ReadOnly = false;
                dest_IPAddr.ReadOnly = false;
                src_Name.ReadOnly = false;
                dest_Name.ReadOnly = false;
                src_PortNum.ReadOnly = false;
                dest_PortNum.ReadOnly = false;
            }
        }

        /// <summary>
        /// Organizes the input channels and their attributes
        /// </summary>
        private void src_listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //load the attributes of the selected value
            src_Name.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 0);
            src_IPAddr.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 1);
            src_PortNum.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 2);

            //adjust button to properties
            adjust_Button();
        }

        /// <summary>
        /// Organizes the output channels and their attributes
        /// </summary>
        private void dest_listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //load the attributes of the selected value
            dest_Name.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 0);
            dest_IPAddr.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 1);
            dest_PortNum.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 2);

            //adjust button to properties
            adjust_Button();
        }

        /// <summary>
        /// 
        /// </summary>
        private void src_Name_TextChanged(object sender, EventArgs e)
        {
            //if nothing is selected then dont allow value input
            if (src_listBox.SelectedIndex < 0)
            {
                src_Name.Clear();
                return;
            }

            ch_mngr.set_Channel_Information("Sources", src_listBox.SelectedIndex, 0, src_Name.Text);

            refresh_ListBoxes();
        }

        /// <summary>
        /// 
        /// </summary>
        private void dest_Name_TextChanged(object sender, EventArgs e)
        {
            //if nothing is selected then dont allow value input
            if (dest_listBox.SelectedIndex < 0)
            {
                dest_Name.Clear();
                return;
            }

            ch_mngr.set_Channel_Information("Destinations", dest_listBox.SelectedIndex, 0, dest_Name.Text);

            refresh_ListBoxes();
        }

        /// <summary>
        /// Notifies channel manger of a change in the source IP value for
        /// the selected channel
        /// </summary>
        private void src_IPAddr_TextChanged(object sender, EventArgs e)
        {
            //if nothing is selected then dont allow value input
            if (src_listBox.SelectedIndex < 0)
            {
                src_IPAddr.Clear();
                return;
            }

            ch_mngr.set_Channel_Information("Sources", src_listBox.SelectedIndex, 1, src_IPAddr.Text);

            //adjust button to properties
            adjust_Button();
        }

        /// <summary>
        /// Notifies channel manger of a change in the destination IP value for
        /// the selected channel
        /// </summary>
        private void dest_IPAddr_TextChanged(object sender, EventArgs e)
        {
            //if nothing is selected then dont allow value input
            if (dest_listBox.SelectedIndex < 0)
            {
                dest_IPAddr.Clear();
                return;
            }

            ch_mngr.set_Channel_Information("Destinations", dest_listBox.SelectedIndex, 1, dest_IPAddr.Text);

            //adjust button to properties
            adjust_Button();
        }

        /// <summary>
        /// Notifies channel manger of a change in the source port value for
        /// the selected channel
        /// </summary>
        private void src_PortNum_TextChanged(object sender, EventArgs e)
        {
            //if nothing is selected then dont allow value input
            if (src_listBox.SelectedIndex < 0)
            {
                src_PortNum.Clear();
                return;
            }

            ch_mngr.set_Channel_Information("Sources", src_listBox.SelectedIndex, 2, src_PortNum.Text);

            //adjust button to properties
            adjust_Button();
        }

        /// <summary>
        /// Notifies channel manger of a change in the destination Port value for
        /// the selected channel
        /// </summary>
        private void dest_PortNum_TextChanged(object sender, EventArgs e)
        {
            //if nothing is selected then dont allow value input
            if (dest_listBox.SelectedIndex < 0)
            {
                dest_PortNum.Clear();
                return;
            }

            ch_mngr.set_Channel_Information("Destinations", dest_listBox.SelectedIndex, 2, dest_PortNum.Text);

            //adjust button to properties
            adjust_Button();
        }

        /// <summary>
        /// Establish a connection between the source and destination.
        /// Update Connection Manager to be aware of this.
        /// Update Channel Manager about the assignment of a source and a destination.
        /// Establish threads of execution.
        /// </summary>
        private void take_Button_Click(object sender, EventArgs e)
        {
            //check for no values
            if (String.IsNullOrEmpty(src_PortNum.Text) || String.IsNullOrEmpty(src_IPAddr.Text)
                || String.IsNullOrEmpty(dest_PortNum.Text) || String.IsNullOrEmpty(dest_IPAddr.Text))
            {
                MessageBox.Show("No Empty fields allowed!", "Empty Field Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //convert to integers
            int src_PortNumber = Convert.ToInt32(src_PortNum.Text);
            int dest_PortNumber = Convert.ToInt32(dest_PortNum.Text);

            if (cn_mngr.Connect(src_IPAddr.Text, src_PortNumber, dest_IPAddr.Text, dest_PortNumber))
            {
                //update button image
                take_Button.BackgroundImage = global::Simple_Switcher.Properties.Resources.stop_Z;

                //also make fields not editable
                src_IPAddr.ReadOnly = true;
                dest_IPAddr.ReadOnly = true;
                src_Name.ReadOnly = true;
                dest_Name.ReadOnly = true;
                src_PortNum.ReadOnly = true;
                dest_PortNum.ReadOnly = true;
            }
            else{
                if (cn_mngr.Is_Connected(src_IPAddr.Text, src_PortNumber, dest_IPAddr.Text, dest_PortNumber))
                {
                    //disconnect it
                    cn_mngr.Disconnect(src_IPAddr.Text, src_PortNumber, dest_IPAddr.Text, dest_PortNumber);
                    //update button image
                    take_Button.BackgroundImage = global::Simple_Switcher.Properties.Resources.take;
                    //make fields editable
                    src_IPAddr.ReadOnly = false;
                    dest_IPAddr.ReadOnly = false;
                    src_Name.ReadOnly = false;
                    dest_Name.ReadOnly = false;
                    src_PortNum.ReadOnly = false;
                    dest_PortNum.ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// When the form exits make sure there are no
        /// channel threads running
        /// </summary>
        private void simple_Switcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            //make sure no threads are still running
            cn_mngr.DisconnectAll();
        }

        private void src_Add_Click(object sender, EventArgs e)
        {
            //open add window
            AddForm addWindow = new AddForm();

            //show as modal
            if (addWindow.ShowDialog() == DialogResult.OK)
            {
                ch_mngr.add_Channel("Sources", addWindow.add_Name, 
                    addWindow.add_IP, Convert.ToInt32(addWindow.add_Port));

                addWindow.Close();
            }
            else
            {
                return;
            }

            //update the list
            refresh_ListBoxes();
        }

        private void dest_Add_Click(object sender, EventArgs e)
        {
            //open add window
            AddForm addWindow = new AddForm();

            //show as modal
            if (addWindow.ShowDialog() == DialogResult.OK)
            {
                ch_mngr.add_Channel("Destinations", addWindow.add_Name,
                    addWindow.add_IP, Convert.ToInt32(addWindow.add_Port));

                addWindow.Close();
            }
            else
            {
                return;
            }

            //update the list
            refresh_ListBoxes();
        }

        private void src_Del_Click(object sender, EventArgs e)
        {
            //before removing stop the connection
            for (int i = 0; i < dest_listBox.Items.Count && !String.IsNullOrEmpty(src_IPAddr.Text)
                && !String.IsNullOrEmpty(src_PortNum.Text); i++)
            {
                string IP_dest = ch_mngr.get_Channel_Information("Destinations", i, 1);
                int Port_dest = Convert.ToInt32(ch_mngr.get_Channel_Information("Destinations", i, 2));

                if (cn_mngr.Is_Connected(src_IPAddr.Text, Convert.ToInt32(src_PortNum.Text), IP_dest, Port_dest))
                {
                    cn_mngr.Disconnect(src_IPAddr.Text, Convert.ToInt32(src_PortNum), IP_dest, Port_dest);
                }
            }

            //clear the text fields, before removing
            src_Name.Clear();
            src_IPAddr.Clear();
            src_PortNum.Clear();

            //
            ch_mngr.remove_Channel("Sources", src_listBox.SelectedItem.ToString());

            //update the list
            src_listBox.Items.Clear();
            
            for (int i = 0; i < ch_mngr.number_of_Src_Channels; i++)
            {
                src_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Sources", i, 0));
            }
            
        }

        private void dest_Del_Click(object sender, EventArgs e)
        {
            //before removing stop the connection
            for (int i = 0; i < src_listBox.Items.Count && !String.IsNullOrEmpty(dest_IPAddr.Text)
                && !String.IsNullOrEmpty(dest_PortNum.Text); i++)
            {
                string IP_src = ch_mngr.get_Channel_Information("Sources", i, 1);
                int Port_src = Convert.ToInt32(ch_mngr.get_Channel_Information("Sources", i, 2));

                if (cn_mngr.Is_Connected(dest_IPAddr.Text, Convert.ToInt32(dest_PortNum.Text), IP_src, Port_src))
                {
                    cn_mngr.Disconnect(dest_IPAddr.Text, Convert.ToInt32(dest_PortNum), IP_src, Port_src);
                }
            }

            //clear the text fields, before removing
            dest_Name.Clear();
            dest_IPAddr.Clear();
            dest_PortNum.Clear();

            //
            ch_mngr.remove_Channel("Destinations", dest_listBox.SelectedItem.ToString());

            //update the list
            dest_listBox.Items.Clear();

            for (int i = 0; i < ch_mngr.number_of_Dest_Channels; i++)
            {
                dest_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Destinations", i, 0));
            }
        }

        private void showSplash()
        {
            //create the splash screen
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.ShowDialog();
        }
    }
}