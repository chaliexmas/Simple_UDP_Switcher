using System;
using System.Threading;
using System.Collections;

namespace Simple_Switcher
{
    class Connections_Manager
    {
        //Data structure used to keep track of data connections
        ArrayList Connections = new ArrayList();

        ~Connections_Manager()
        {
            //make sure no thread are left running
            DisconnectAll();
        }

        public bool Connect(string in_IP, int in_Port, string out_IP, int out_Port)
        {
            
            foreach (Connection con in Connections)
            {
                //check if the connection already exists
                if (con.src_IPAddress == in_IP && con.src_PortNum == in_Port &&
                    con.dest_IPAddress == out_IP && con.dest_PortNum == out_Port)
                {
                    return false;
                }
                //check the destination for already having a source(any)
                if (con.dest_IPAddress == out_IP && con.dest_PortNum == out_Port)
                {
                    return false;
                }
            }
            
            //create the connection, check it, and store it
            Connection conn = new Connection(in_IP, in_Port, out_IP, out_Port);
            return true;
        }

        public bool Is_Connected(string in_IP, int in_Port, string out_IP, int out_Port)
        {
            //search the array for the connection
            foreach (Connection con in Connections)
            {
                //found
                if (con.src_IPAddress == in_IP && con.src_PortNum == in_Port &&
                    con.dest_IPAddress == out_IP && con.dest_PortNum == out_Port)
                {
                    //end the search
                    return true;
                }
                //if found then disconnect all with same dest
                if (con.src_IPAddress == "" && con.src_PortNum == 0 &&
                    con.dest_IPAddress == out_IP && con.dest_PortNum == out_Port)
                {
                    //tell it to end running thread
                    //end the search
                    return true;
                }
                //if found then disconnect all with same src
                if (con.src_IPAddress == in_IP && con.src_PortNum == in_Port &&
                    con.dest_IPAddress == "" && con.dest_PortNum == 0)
                {
                    //tell it to end running thread
                    //end the search
                    return true;
                }
            }

            //not found 
            return false;
        }

        public bool Disconnect(string in_IP, int in_Port, string out_IP, int out_Port)
        {
            //search the array for the connection
            foreach (Connection con in Connections)
            {
                //if found then disconnect
                if (con.src_IPAddress == in_IP && con.src_PortNum == in_Port &&
                    con.dest_IPAddress == out_IP && con.dest_PortNum == out_Port)
                {
                    //tell it to end running thread
                    con.runStatus = false;
                    //remove it from the array
                    Connections.Remove(con);
                    
                    //end the search
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Safety method for releassing all connections
        /// </summary>
        public void DisconnectAll()
        {
            //search the array for the connection
            for (int i = 0; i < Connections.Count; i++)
            {
                Connection con = (Connection)Connections[i];
                
                //end the running thread
                con.runStatus = false;

                //get the thread and wait for it to end
                while (con.get_Thread().IsAlive)
                {
                    con.get_Thread().Abort();
                }

                //remove the object
                Connections.RemoveAt(i);
            }
        }
    }
}
