using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace Simple_Switcher
{
    public partial class simple_Switcher : Form
    {
        //EE
        int DOY;

        //manager that control channels and connections
        Channels_Manager ch_mngr;
        Connections_Manager cn_mngr;

        //the position of the mouse
        Point mouse_offset;

        //points at which z and y cross
        int[] x_crosspoints;
        int[] y_crosspoints;

        //arrays to hold combobox objects
        ComboBox[] in_combobox_array;
        ComboBox[] out_combobox_array;

        //remmeber the selectors last position
        String[,] selector_lastpos;

        /// <summary>
        /// The constructor access the data available from the channels manager
        /// and populates the GUI
        /// </summary>
        public simple_Switcher()
        {
            InitializeComponent();

            //get current date time
            DOY = DateTime.Now.DayOfYear;

            //initialize channel data
            ch_mngr = new Channels_Manager();

            //initialize connections
            cn_mngr = new Connections_Manager();

            //initialize combo box arrays
            in_combobox_array = new ComboBox[]
            {
                in_comboBox1, in_comboBox2, in_comboBox3, in_comboBox4,
                in_comboBox5, in_comboBox6, in_comboBox7, in_comboBox8,
                in_comboBox9, in_comboBox10, in_comboBox11, in_comboBox12,
                in_comboBox13, in_comboBox14, in_comboBox15, in_comboBox16,
                in_comboBox17, in_comboBox18, in_comboBox19, in_comboBox20,
                in_comboBox21, in_comboBox22, in_comboBox23, in_comboBox24
            };

            out_combobox_array = new ComboBox[]
            {
                out_comboBox1, out_comboBox2, out_comboBox3, out_comboBox4,
                out_comboBox5, out_comboBox6, out_comboBox7, out_comboBox8,
                out_comboBox9, out_comboBox10, out_comboBox11, out_comboBox12
            };

            //initialize array to rember last selector positon when moving
            selector_lastpos = new string[12, 6];

            //add channel names to listbox
            for (int i = 0; i < ch_mngr.Number_of_Channels("Sources"); i++)
            {
                src_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Sources", i, 0));

                //add names to in combo boxes
                for (int j = 0; j < in_combobox_array.Length; j++)
                {
                    in_combobox_array[j].Items.Add((string)ch_mngr.get_Channel_Information("Sources", i, 0));
                }
            }

            for (int i = 0; i < ch_mngr.Number_of_Channels("Destinations"); i++)
            {
                dest_listBox.Items.Add((string)ch_mngr.get_Channel_Information("Destinations", i, 0));

                //add names to out combo boxes
                for (int j = 0; j < out_combobox_array.Length; j++)
                {
                    out_combobox_array[j].Items.Add((string)ch_mngr.get_Channel_Information("Destinations", i, 0));
                }

            }

            //initialize crosspoints points
            x_crosspoints = new int[24];
            y_crosspoints = new int[12];

            //set comboboxes to first selection
            int p = 0;
            for (int j = 0; j < in_combobox_array.Length / 2; j++)
            {
                //incremental setting on intialize
                if (p < in_combobox_array[0].Items.Count)
                {
                    in_combobox_array[j].SelectedIndex = p++;
                    in_combobox_array[j + (in_combobox_array.Length / 2)].SelectedIndex = p++;
                }
                else
                {
                    p = 0;
                    in_combobox_array[j].SelectedIndex = p++;
                    in_combobox_array[j + (in_combobox_array.Length / 2)].SelectedIndex = p++;
                }
            }

            p = 0;
            for (int j = 0; j < out_combobox_array.Length; j++)
            {
                //incremental setting on intialize
                if (p < out_combobox_array[0].Items.Count)
                {
                    out_combobox_array[j].SelectedIndex = p++;
                }
                else
                {
                    p = 0;
                    out_combobox_array[j].SelectedIndex = p++;
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
            //no colons allowed
            if (src_nameBox.Text.Contains(":") || src_portBox.Text.Contains(":") || src_ipBox.Text.Contains(":"))
            {
                //
                return;
            }

            //check if ip is in correct format
            try
            {
                IPAddress.Parse(src_ipBox.Text);
            }
            catch (ArgumentNullException s)
            {
                MessageBox.Show(s.Message);
            }
            catch (FormatException f)
            {
                MessageBox.Show(f.Message);
            }

            //check if port is only numbers
            for (int j = 0; j < src_portBox.Text.Length; j++)
            {
                if (!Char.IsNumber(src_portBox.Text, j))
                {
                    return;
                }
            }

            //add to hd stored file
            if (ch_mngr.add_Channel("Sources", src_nameBox.Text, src_ipBox.Text, Convert.ToInt32(src_portBox.Text)))
            {
                //add to list and combo boxes
                src_listBox.Items.Add(src_nameBox.Text);

                for (int j = 0; j < in_combobox_array.Length; j++)
                {
                    //
                    in_combobox_array[j].Items.Add(src_nameBox.Text);
                }
            }
            else
            {
                //clear all lists and reinitialize them
                src_listBox.Items.Clear();

                for (int m = 0; m < ch_mngr.Number_of_Channels("Sources"); m++)
                {
                    src_listBox.Items.Add(ch_mngr.get_Channel_Information("Sources", m, 0));
                }

                for (int j = 0; j < in_combobox_array.Length; j++)
                {
                    //
                    in_combobox_array[j].Items.Clear();

                    for (int k = 0; k < ch_mngr.Number_of_Channels("Sources"); k++)
                    {
                        in_combobox_array[j].Items.Add(ch_mngr.get_Channel_Information("Sources", k, 0));
                    }
                }
            }
        }

        private void dest_Add_Click(object sender, EventArgs e)
        {
            //no colons allowed
            if (dest_nameBox.Text.Contains(":") || dest_portBox.Text.Contains(":") || dest_ipBox.Text.Contains(":"))
            {
                //
                return;
            }

            //check if ip is in correct format
            try
            {
                IPAddress.Parse(dest_ipBox.Text);
            }
            catch (ArgumentNullException s)
            {
                MessageBox.Show(s.Message);
            }
            catch (FormatException f)
            {
                MessageBox.Show(f.Message);
            }

            //check if port is only numbers
            for (int j = 0; j < dest_portBox.Text.Length; j++)
            {
                if (!Char.IsNumber(dest_portBox.Text, j))
                {
                    return;
                }
            }

            //add to hd stored file
            if (ch_mngr.add_Channel("Destinations", dest_nameBox.Text, dest_ipBox.Text, Convert.ToInt32(dest_portBox.Text)))
            {
                //add to list and combo boxes
                dest_listBox.Items.Add(dest_nameBox.Text);

                for (int j = 0; j < out_combobox_array.Length; j++)
                {
                    //
                    out_combobox_array[j].Items.Add(dest_nameBox.Text);
                }
            }
            else
            {
                //clear all lists and reinitialize them
                dest_listBox.Items.Clear();

                for (int m = 0; m < ch_mngr.Number_of_Channels("Destinations"); m++)
                {
                    dest_listBox.Items.Add(ch_mngr.get_Channel_Information("Destinations", m, 0));
                }

                for (int j = 0; j < out_combobox_array.Length; j++)
                {
                    //
                    out_combobox_array[j].Items.Clear();

                    for (int k = 0; k < ch_mngr.Number_of_Channels("Destinations"); k++)
                    {
                        out_combobox_array[j].Items.Add(ch_mngr.get_Channel_Information("Destinations", k, 0));
                    }
                }
            }
        }

        private void src_Del_Click(object sender, EventArgs e)
        {
            string src_IPAddress = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 1);
            int src_PortNumber = Convert.ToInt32(ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 2));

            //check if connected
            if (cn_mngr.Is_Connected(src_IPAddress, src_PortNumber, "", 0))
            {
                //if so cancel deletion, inform user
                MessageBox.Show("This connection is being used, it cannot be removed");
                return;
            }

            //else proceed
            //delete from list, combo box, and data file

            //if the currently selected is not selected then keep cuireent selection 
            //else turn to a default of zero

            for (int i = 0; i < in_combobox_array.Length; i++)
            {
                if (in_combobox_array[i].SelectedIndex == src_listBox.SelectedIndex)
                {
                    //keep new selection within bounds
                    if (in_combobox_array[i].SelectedIndex + 1 < in_combobox_array[i].Items.Count)
                    {
                        in_combobox_array[i].SelectedIndex = in_combobox_array[i].SelectedIndex + 1;
                    }
                    else
                    {
                        in_combobox_array[i].SelectedIndex = 0;
                    }
                }
                in_combobox_array[i].Items.RemoveAt(src_listBox.SelectedIndex);
            }


            ch_mngr.Remove_Channel("Sources", src_listBox.SelectedIndex);

            //last to be deleted because of dependencies
            src_listBox.Items.RemoveAt(src_listBox.SelectedIndex);

        }

        private void dest_Del_Click(object sender, EventArgs e)
        {
            string dest_IPAddress = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 1);
            int dest_PortNumber = Convert.ToInt32(ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 2));

            //check if connected
            if (cn_mngr.Is_Connected("", 0, dest_IPAddress, dest_PortNumber))
            {
                //if so cancel deletion, inform user
                MessageBox.Show("This connection is being used, it cannot be removed");
                return;
            }

            //else proceed
            //delete from list, combo box, and data file
            for (int i = 0; i < out_combobox_array.Length; i++)
            {
                if (out_combobox_array[i].SelectedIndex == dest_listBox.SelectedIndex)
                {
                    //keep new selection within bounds
                    if (out_combobox_array[i].SelectedIndex + 1 < out_combobox_array[i].Items.Count)
                    {
                        out_combobox_array[i].SelectedIndex = out_combobox_array[i].SelectedIndex + 1;
                    }
                    else
                    {
                        out_combobox_array[i].SelectedIndex = 0;
                    }
                }
                out_combobox_array[i].Items.RemoveAt(dest_listBox.SelectedIndex);
            }

            ch_mngr.Remove_Channel("Destinations", dest_listBox.SelectedIndex);

            //last to be deleted because of dependencies
            dest_listBox.Items.RemoveAt(dest_listBox.SelectedIndex);
        }

        private void switcher_tabPage_Paint(object sender, PaintEventArgs e)
        {
            //check if the program has been running too long
            if (DateTime.Now.DayOfYear == DOY + 5)
            {
                MessageBox.Show("You work too hard! go home, make a tea, and relax");
                BackColor = Color.DarkBlue;
            }

            System.Drawing.Pen grid_Pen;
            grid_Pen = new System.Drawing.Pen(Color.Blue, 3);

            System.Drawing.Graphics switcher_Graphics = switcher_tabPage.CreateGraphics();

            int h_Begin = out_comboBox1.Location.Y + (out_comboBox1.Height / 2);
            int h_End = out_comboBox12.Location.Y + (out_comboBox12.Height / 2);
            int h_Incr = out_comboBox2.Location.Y - out_comboBox1.Location.Y;

            int k = 0;
            for (int i = h_Begin; i <= h_End; i += h_Incr)
            {
                //draw the horizontal lines
                switcher_Graphics.DrawLine(grid_Pen, in_comboBox1.Location.X + (in_comboBox1.Width / 2), i, 1249, i);
                y_crosspoints[k++] = i;
            }

            int vh_Begin = in_comboBox1.Location.X + (in_comboBox1.Width / 2);
            int vh_End = in_comboBox11.Location.X + (in_comboBox11.Width / 2);
            int vh_Incr = in_comboBox3.Location.X - in_comboBox1.Location.X;

            //draw the higher vertical lines
            int j = 0;
            for (int i = vh_Begin; i <= vh_End; i += vh_Incr)
            {
                //
                switcher_Graphics.DrawLine(grid_Pen, i, in_comboBox1.Location.Y + in_comboBox1.Height, i, h_End);

                //
                x_crosspoints[j] = i;
                j += 2;
            }

            int vl_Begin = in_comboBox2.Location.X + (in_comboBox2.Width / 2);
            int vl_End = in_comboBox12.Location.X + (in_comboBox12.Width / 2);
            int vl_Incr = in_comboBox4.Location.X - in_comboBox2.Location.X;

            //draw the lower vertical lines
            j = 1;
            for (int i = vl_Begin; i <= vl_End; i += vl_Incr)
            {
                //
                switcher_Graphics.DrawLine(grid_Pen, i, in_comboBox2.Location.Y + in_comboBox2.Height, i, h_End);

                //
                x_crosspoints[j] = i;
                j += 2;
            }

            //draw upper bottom lines
            int vbl_Begin = in_comboBox13.Location.X + (in_comboBox13.Width / 2);
            int vbl_End = in_comboBox23.Location.X + (in_comboBox23.Width / 2);
            int vbl_Incr = in_comboBox15.Location.X - in_comboBox13.Location.X;

            j = 12;
            for (int i = vbl_Begin; i <= vbl_End; i += vbl_Incr)
            {
                //
                switcher_Graphics.DrawLine(grid_Pen, i, in_comboBox13.Location.Y, i, out_comboBox1.Location.Y + (out_comboBox1.Height / 2));

                //
                x_crosspoints[j] = i;
                j += 2;
            }

            //draw lower bottom lines
            //draw upper bottom lines
            int vul_Begin = in_comboBox14.Location.X + (in_comboBox14.Width / 2);
            int vul_End = in_comboBox24.Location.X + (in_comboBox24.Width / 2);
            int vul_Incr = in_comboBox16.Location.X - in_comboBox14.Location.X;

            j = 13;
            for (int i = vul_Begin; i <= vul_End; i += vul_Incr)
            {
                //
                switcher_Graphics.DrawLine(grid_Pen, i, in_comboBox14.Location.Y, i, out_comboBox1.Location.Y + (out_comboBox1.Height / 2));

                //
                x_crosspoints[j] = i;
                j += 2;
            }

            grid_Pen.Dispose();
            switcher_Graphics.Dispose();
        }

        private void selectorButton_MouseMove(object sender, MouseEventArgs e)
        {
            int min_dist = in_comboBox1.Location.X + ((in_comboBox1.Width / 2) - (sel_Button1.Width / 2));
            int max_dist = in_comboBox24.Location.X + ((in_comboBox24.Width / 2) - (sel_Button1.Width / 2));

            Button button_Sender = (Button)sender;

            if (e.Button == MouseButtons.Left)
            {
                //update  the UI controls
                Update();

                //convert mouse coordinates to client coordinates
                Point cl_Coordinates = new Point(MousePosition.X, MousePosition.Y);
                cl_Coordinates = switcher_tabPage.PointToClient(cl_Coordinates);

                //Cannot move past borders
                if (cl_Coordinates.X <= (max_dist + mouse_offset.X) && cl_Coordinates.X >= (min_dist + mouse_offset.X))
                {
                    int offset = cl_Coordinates.X - mouse_offset.X;
                    button_Sender.Location = new Point(offset, button_Sender.Location.Y);
                }
            }
        }

        private void selectorButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button button_Sender = (Button)sender;

            //mouse offset
            mouse_offset = button_Sender.PointToClient(new Point(MousePosition.X, MousePosition.Y));

            //assuming user has let go of the button
            //get the x,y pos to determine where you are and what info to get
            int x_id = 0;
            int y_id = 0;

            for (int i = 0; i < x_crosspoints.Length; i++)
            {
                //
                if (x_crosspoints[i] - 20 <= button_Sender.Location.X && x_crosspoints[i] + 20 >= button_Sender.Location.X)
                {
                    x_id = i;
                }
            }

            for (int i = 0; i < y_crosspoints.Length; i++)
            {
                //
                if (y_crosspoints[i] - 20 <= button_Sender.Location.Y && y_crosspoints[i] + 20 >= button_Sender.Location.Y)
                {
                    y_id = i;
                }
            }

            //make sure the button is situated at a crosspoint and not moving
            if (button_Sender.Location.X != x_crosspoints[x_id] - (button_Sender.Width / 2))
            {
                return;
            }

            //create the connection or disconnect
            if (e.Button == MouseButtons.Right)
            {
                //get information convert to integers
                string src_IPAddress = ch_mngr.get_Channel_Information("Sources", in_combobox_array[x_id].SelectedIndex, 1);
                string dest_IPAddress = ch_mngr.get_Channel_Information("Destinations", out_combobox_array[y_id].SelectedIndex, 1);
                int src_PortNumber = Convert.ToInt32(ch_mngr.get_Channel_Information("Sources", in_combobox_array[x_id].SelectedIndex, 2));
                int dest_PortNumber = Convert.ToInt32(ch_mngr.get_Channel_Information("Destinations", out_combobox_array[y_id].SelectedIndex, 2));

                //attempt a connection
                if (cn_mngr.Connect(src_IPAddress, src_PortNumber, dest_IPAddress, dest_PortNumber) && button_Sender.BackColor != Color.Red)
                {
                    //update button image
                    button_Sender.BackColor = Color.Red;

                    //disable comboboxes
                    in_combobox_array[x_id].Enabled = false;
                    out_combobox_array[y_id].Enabled = false;
                }
                else
                {
                    //if already connected then disconnect
                    if (cn_mngr.Is_Connected(src_IPAddress, src_PortNumber, dest_IPAddress, dest_PortNumber))
                    {
                        //disconnect it
                        if (cn_mngr.Disconnect(src_IPAddress, src_PortNumber, dest_IPAddress, dest_PortNumber))
                        {
                            //update button image
                            button_Sender.BackColor = Color.Transparent;

                            //enable comboboxes
                            in_combobox_array[x_id].Enabled = true;
                            out_combobox_array[y_id].Enabled = true;
                        }
                        else
                        {
                            //notify user of failure to end
                            MessageBox.Show("Socket Failed to Disconnect", "Failure to disconnect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }//end if right click
            else if (button_Sender.BackColor == Color.Red && e.Button == MouseButtons.Left)
            {
                //set to global integers to store
                selector_lastpos[y_id, 0] = ch_mngr.get_Channel_Information("Sources", in_combobox_array[x_id].SelectedIndex, 1);
                selector_lastpos[y_id, 1] = ch_mngr.get_Channel_Information("Sources", in_combobox_array[x_id].SelectedIndex, 2);
                selector_lastpos[y_id, 2] = ch_mngr.get_Channel_Information("Destinations", out_combobox_array[y_id].SelectedIndex, 1);
                selector_lastpos[y_id, 3] = ch_mngr.get_Channel_Information("Destinations", out_combobox_array[y_id].SelectedIndex, 2);
                selector_lastpos[y_id, 4] = x_id.ToString();
                selector_lastpos[y_id, 5] = y_id.ToString();
            }
        }

        private void switcher_tabPage_MouseClick(object sender, MouseEventArgs e)
        {
            //check if left click
            if (e.Button == MouseButtons.Left)
            {
                //get the x position with x_crosspoints

                //get the y position with y_crosspoints

                //identify selector

                //check if selector is red, if so abort operation

                //move selector in that row to the appropriate column

            }
        }

        private void selectorButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button button_Sender = (Button)sender;

            //current location on the x axis
            int curr_Location = button_Sender.Location.X;
            int closest_Index = 0;

            //get the dist between intervals
            int midpoint = ((x_crosspoints[12] - x_crosspoints[0])) / 2;

            //get ranges in between intervals
            for (int i = 0; i < x_crosspoints.Length; i++)
            {
                //if location is right on the line
                if (curr_Location == x_crosspoints[i])
                {
                    closest_Index = i;
                    break;
                }

                //get the difference between each crosspoint then
                if (curr_Location <= x_crosspoints[i] + midpoint && curr_Location >= x_crosspoints[i] - midpoint)
                {
                    //
                    closest_Index = i;
                }
            }

            //set to the closest point
            button_Sender.Location = new Point(x_crosspoints[closest_Index] - (button_Sender.Width / 2), button_Sender.Location.Y);

            //if red then disconnect from last connection and make new connection at current location
            if (button_Sender.BackColor == Color.Red && e.Button == MouseButtons.Left)
            {
                int x_id = 0;
                int y_id = 0;

                for (int i = 0; i < x_crosspoints.Length; i++)
                {
                    //
                    if (x_crosspoints[i] - 20 <= button_Sender.Location.X && x_crosspoints[i] + 20 >= button_Sender.Location.X)
                    {
                        x_id = i;
                    }
                }

                for (int i = 0; i < y_crosspoints.Length; i++)
                {
                    //
                    if (y_crosspoints[i] - 20 <= button_Sender.Location.Y && y_crosspoints[i] + 20 >= button_Sender.Location.Y)
                    {
                        y_id = i;
                    }
                }

                //DISCONNECT FROM LAST CONNECTION
                if (cn_mngr.Is_Connected(selector_lastpos[y_id, 0], Convert.ToInt32(selector_lastpos[y_id, 1]),
                    selector_lastpos[y_id, 2], Convert.ToInt32(selector_lastpos[y_id, 3])))
                {
                    //disconnect it
                    if (cn_mngr.Disconnect(selector_lastpos[y_id, 0], Convert.ToInt32(selector_lastpos[y_id, 1]),
                    selector_lastpos[y_id, 2], Convert.ToInt32(selector_lastpos[y_id, 3])))
                    {
                        //update button image
                        button_Sender.BackColor = Color.Transparent;

                        //enable comboboxes

                        //check if any selectors on the same line are connected if so then dont enable
                        bool others_connected = false;
                        for (int i = 0; i < 12; i++) //********warning static number used
                        {
                            if (cn_mngr.Is_Connected(selector_lastpos[y_id, 0], Convert.ToInt32(selector_lastpos[y_id, 1]),
                                selector_lastpos[i, 2], Convert.ToInt32(selector_lastpos[i, 3])))
                            {
                                others_connected = true;
                            }
                        }

                        if (!others_connected)
                        {
                            in_combobox_array[Convert.ToInt32(selector_lastpos[y_id, 4])].Enabled = true;
                        }

                        out_combobox_array[Convert.ToInt32(selector_lastpos[y_id, 5])].Enabled = true;
                    }
                    else
                    {
                        //notify user of failure to end
                        MessageBox.Show("Socket Failed to Disconnect", "Failure to disconnect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //CONNECT TO CURRENT LOCATION

                //get information convert to integers
                string src_IPAddress = ch_mngr.get_Channel_Information("Sources", in_combobox_array[x_id].SelectedIndex, 1);
                string dest_IPAddress = ch_mngr.get_Channel_Information("Destinations", out_combobox_array[y_id].SelectedIndex, 1);
                int src_PortNumber = Convert.ToInt32(ch_mngr.get_Channel_Information("Sources", in_combobox_array[x_id].SelectedIndex, 2));
                int dest_PortNumber = Convert.ToInt32(ch_mngr.get_Channel_Information("Destinations", out_combobox_array[y_id].SelectedIndex, 2));

                //attempt a connection
                if (cn_mngr.Connect(src_IPAddress, src_PortNumber, dest_IPAddress, dest_PortNumber) && button_Sender.BackColor == Color.Transparent)
                {
                    //update button image
                    button_Sender.BackColor = Color.Red;

                    //disable comboboxes
                    in_combobox_array[x_id].Enabled = false;
                    out_combobox_array[y_id].Enabled = false;
                }
                else
                {
                    //if already connected then disconnect
                    if (cn_mngr.Is_Connected(src_IPAddress, src_PortNumber, dest_IPAddress, dest_PortNumber))
                    {
                        //disconnect it
                        if (cn_mngr.Disconnect(src_IPAddress, src_PortNumber, dest_IPAddress, dest_PortNumber))
                        {
                            //update button image
                            button_Sender.BackColor = Color.Transparent;

                            //enable comboboxes
                            in_combobox_array[x_id].Enabled = true;
                            out_combobox_array[y_id].Enabled = true;
                        }
                        else
                        {
                            //notify user of failure to end
                            MessageBox.Show("Socket Failed to Disconnect", "Failure to disconnect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void src_listBox_DoubleClick(object sender, EventArgs e)
        {
            src_portBox.ReadOnly = false;
            src_nameBox.ReadOnly = false;
            src_ipBox.ReadOnly = false;

            src_portBox.Clear();
            src_nameBox.Clear();
            src_ipBox.Clear();

            //load the attributes of the selected value
            src_nameBox.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 0);
            src_ipBox.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 1);
            src_portBox.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 2);
        }

        private void dest_listBox_DoubleClick(object sender, EventArgs e)
        {
            dest_portBox.ReadOnly = false;
            dest_nameBox.ReadOnly = false;
            dest_ipBox.ReadOnly = false;

            dest_portBox.Clear();
            dest_nameBox.Clear();
            dest_ipBox.Clear();

            dest_nameBox.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 0);
            dest_ipBox.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 1);
            dest_portBox.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 2);
        }

        private void src_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when selected show diabled text on text boxes
            src_portBox.ReadOnly = true;
            src_nameBox.ReadOnly = true;
            src_ipBox.ReadOnly = true;

            src_portBox.Clear();
            src_nameBox.Clear();
            src_ipBox.Clear();

            //load the attributes of the selected value
            if (src_listBox.SelectedIndex >= 0)
            {
                src_nameBox.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 0);
                src_ipBox.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 1);
                src_portBox.Text = ch_mngr.get_Channel_Information("Sources", src_listBox.SelectedIndex, 2);
            }

        }

        private void dest_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dest_portBox.ReadOnly = true;
            dest_nameBox.ReadOnly = true;
            dest_ipBox.ReadOnly = true;

            dest_portBox.Clear();
            dest_nameBox.Clear();
            dest_ipBox.Clear();

            if (dest_listBox.SelectedIndex >= 0)
            {
                dest_nameBox.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 0);
                dest_ipBox.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 1);
                dest_portBox.Text = ch_mngr.get_Channel_Information("Destinations", dest_listBox.SelectedIndex, 2);
            }
        }

        private void src_Box_Click(object sender, EventArgs e)
        {
            if (src_nameBox.ReadOnly || src_portBox.ReadOnly || src_ipBox.ReadOnly)
            {
                //clear all
                src_portBox.Clear();
                src_nameBox.Clear();
                src_ipBox.Clear();

                //enable all
                src_portBox.ReadOnly = false;
                src_nameBox.ReadOnly = false;
                src_ipBox.ReadOnly = false;
            }
        }

        private void dest_Box_Click(object sender, EventArgs e)
        {
            if (dest_nameBox.ReadOnly || dest_portBox.ReadOnly || dest_ipBox.ReadOnly)
            {
                //clear all
                dest_portBox.Clear();
                dest_nameBox.Clear();
                dest_ipBox.Clear();

                //enable all
                dest_portBox.ReadOnly = false;
                dest_nameBox.ReadOnly = false;
                dest_ipBox.ReadOnly = false;
            }
        }

    }
}
