using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Simple_Switcher
{
    class Connection
    {
        private string src_IP;
        private int src_Port;
        private string dest_IP;
        private int dest_Port;

        private Socket relay;
        private EndPoint ipend;
        private byte[] data;

        private bool running;
        private Thread runner;

        ~Connection()
        {
            //
            relay.Close();
        }

        /// <summary>
        /// the constructure setsup the connection and runs a thread to constantly realy packets
        /// </summary>
        public Connection(string in_IP, int in_Port, string out_IP, int out_Port)
        {
            //
            src_IP = in_IP;
            src_Port = in_Port;
            dest_IP = out_IP;
            dest_Port = out_Port;
            running = true;

            //
            relay = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            relay.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            ipend = new IPEndPoint(IPAddress.Any, src_Port);
            relay.Bind(ipend);

            relay.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
                new MulticastOption(IPAddress.Parse(src_IP)));

            relay.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1);

            relay.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 64);

            relay.DontFragment = true;

            //
            runner = new Thread(new ThreadStart(run));
            runner.Start();
        }

        /// <summary>
        /// Method that relays the packets, only stopped by setting running variable to false
        /// </summary>
        public void run()
        {
            int size = 64000;
            bool sendit = true;

            while (running)
            {
                data = new byte[size];

                //check for datagram larger than the buffer
                try
                {
                    relay.ReceiveFrom(data, ref ipend);
                }
                catch (SocketException e)
                {
                    //if the error is buffer is too small then increment the buffer
                    if (e.ErrorCode == 10040)
                    {
                        //increment buffer size
                        size += 1;

                        //do not send the data
                        sendit = false;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message + "\n\n Push the disconnect button to reset manually.",
                            "Connection Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                        running = false;
                        break;
                    }
                }

                //dont send data that was not recieved correctly
                if (sendit)
                {
                    relay.SendTo(data, new IPEndPoint(IPAddress.Parse(dest_IP), dest_Port));
                }
                else
                {
                    //reset
                    sendit = true;
                }
            }
            relay.Close();
        }

        public Thread get_Thread()
        {
            return runner;
        }

        public string src_IPAddress
        {
            get { return src_IP; }
            set { src_IP = value; }
        }

        public int src_PortNum
        {
            get { return src_Port; }
            set { src_Port = value; }
        }

        public string dest_IPAddress
        {
            get { return dest_IP; }
            set { dest_IP = value; }
        }

        public int dest_PortNum
        {
            get { return dest_Port; }
            set { dest_Port = value; }
        }

        public bool runStatus
        {
            get { return running; }
            set { running = value; }
        }
    }
}
