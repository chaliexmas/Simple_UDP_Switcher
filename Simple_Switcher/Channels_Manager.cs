using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Simple_Switcher
{
    public class Channels_Manager
    {
        //main data structures
        private List<string> SRC_CHANNELS;
        private List<string> DEST_CHANNELS;

        bool MOD;

        public Channels_Manager()
        {
            //indicates whether modifications have taken place
            MOD = false;
            
            //initalize lists
            SRC_CHANNELS = new List<string>();
            DEST_CHANNELS = new List<string>();

            //check if files does not exist

            string filepath = @"chsrcs.can";

            if (!File.Exists("chsrcs.can"))
            {
                //load defaults into memory
                //name:IP:port
                SRC_CHANNELS.Add("COLORBARS:239.16.33.10:8998");
                SRC_CHANNELS.Add("COLORBARS:239.16.33.10:8999");

                SRC_CHANNELS.Add("Streamer 1A 8901:239.16.33.10:8901");
                SRC_CHANNELS.Add("Streamer 1B 8902:239.16.33.10:8902");
                SRC_CHANNELS.Add("Streamer 2A 8903:239.16.33.10:8903");
                SRC_CHANNELS.Add("Streamer 2B 8904:239.16.33.10:8904");
                SRC_CHANNELS.Add("Streamer 3A 8905:239.16.33.10:8905");
                SRC_CHANNELS.Add("Streamer 3B 8906:239.16.33.10:8906");
                SRC_CHANNELS.Add("Streamer 4A 8907:239.16.33.10:8907");
                SRC_CHANNELS.Add("Streamer 4B 8908:239.16.33.10:8908");
                SRC_CHANNELS.Add("Streamer 5A 8909:239.16.33.10:8909");
                SRC_CHANNELS.Add("Streamer 5B 8910:239.16.33.10:8910");
                SRC_CHANNELS.Add("Streamer 6A 8911:239.16.33.10:8911");
                SRC_CHANNELS.Add("Streamer 6B 8912:239.16.33.10:8912");
                SRC_CHANNELS.Add("Streamer 7A 8913:239.16.33.10:8913");
                SRC_CHANNELS.Add("Streamer 7B 8914:239.16.33.10:8914");
                SRC_CHANNELS.Add("Streamer 8A 8915:239.16.33.10:8915");
                SRC_CHANNELS.Add("Streamer 8B 8916:239.16.33.10:8916");
                SRC_CHANNELS.Add("Streamer 9A 8917:239.16.33.10:8917");
                SRC_CHANNELS.Add("Streamer 9B 8918:239.16.33.10:8918");
                SRC_CHANNELS.Add("Streamer 10A 8919:239.16.33.10:8919");
                SRC_CHANNELS.Add("Streamer 10B 8920:239.16.33.10:8920");

                SRC_CHANNELS.Add("VISOR 1:239.18.25.11:8901");
                SRC_CHANNELS.Add("VISOR 2:239.18.25.11:8902");
                SRC_CHANNELS.Add("VISOR 3:239.18.25.11:8903");
                SRC_CHANNELS.Add("VISOR 4:239.18.25.11:8904");
                SRC_CHANNELS.Add("VISOR 5:239.18.25.11:8905");
                SRC_CHANNELS.Add("VISOR 6:239.18.25.11:8906");
                SRC_CHANNELS.Add("VISOR 7:239.18.25.11:8907");
                SRC_CHANNELS.Add("VISOR 8:239.18.25.11:8908");
                SRC_CHANNELS.Add("VISOR 9:239.18.25.11:8909");
                SRC_CHANNELS.Add("VISOR 10:239.18.25.11:8910");

                SRC_CHANNELS.Add("NTDIS 1:239.18.33.11:8901");
                SRC_CHANNELS.Add("NTDIS 2:239.18.33.11:8902");
                SRC_CHANNELS.Add("NTDIS 3:239.18.33.11:8903");
                SRC_CHANNELS.Add("NTDIS 4:239.18.33.11:8904");

                SRC_CHANNELS.Add("PLAYBACK 1:239.18.33.10:8990");
                SRC_CHANNELS.Add("PLAYBACK 1:239.18.33.10:8991");
            }
            else
            {
                //parse information into data structure
                string[] median = File.ReadAllLines(filepath);

                //load its contents into memory
                foreach (String str in median)
                {
                    SRC_CHANNELS.Add(str);
                }

                //sort the items
                //SRC_CHANNELS.Sort();
            }

            filepath = @"chdest.can";

            if (!File.Exists("chdest.can"))
            {
                //load defaults into memory
                DEST_CHANNELS.Add("VRF Channel 1:239.16.33.11:8901");
                DEST_CHANNELS.Add("VRF Channel 2:239.16.33.11:8902");
                DEST_CHANNELS.Add("VRF Channel 3:239.16.33.11:8903");
                DEST_CHANNELS.Add("VRF Channel 4:239.16.33.11:8904");
                DEST_CHANNELS.Add("VRF Channel 5:239.16.33.11:8905");
                DEST_CHANNELS.Add("VRF Channel 6:239.16.33.11:8906");
                DEST_CHANNELS.Add("VRF Channel 7:239.16.33.11:8907");
                DEST_CHANNELS.Add("VRF Channel 8:239.16.33.11:8908");
                DEST_CHANNELS.Add("VRF Channel 9:239.16.33.11:8909");
                DEST_CHANNELS.Add("VRF Channel 10:239.16.33.11:8910");
                DEST_CHANNELS.Add("VRF Channel 11:239.16.33.11:8911");
                DEST_CHANNELS.Add("VRF Channel 12:239.16.33.11:8912");
            }
            else
            {
                //load its contents into memory
                //parse information into data structure
                string[] median = File.ReadAllLines(filepath);

                //load its contents into memory
                foreach (String str in median)
                {
                    DEST_CHANNELS.Add(str);
                }

                //sort the items
                //DEST_CHANNELS.Sort();
            }
        }

        //before closing save data back to hard drive
        ~Channels_Manager()
        {
            //if there has been a modification to defaults then save the data
            if (MOD)
            {
                Save_Data();
            }
        }

        public string get_Channel_Information(string type, int index, int attribute)
        {
            string temp;

            if (type == "Sources")
            {
                temp = SRC_CHANNELS[index];
            }
            else if (type == "Destinations")
            {
                temp = DEST_CHANNELS[index];
            }
            else
            {
                return "NO DATA";
            }

            //temp format Channel Name:IP:Port
            if (attribute == 0)
            {
                return temp.Substring(0, temp.IndexOf(":"));
            }
            else if (attribute == 1)
            {
                return temp.Substring(temp.IndexOf(":") + 1, ((temp.LastIndexOf(":")) - (temp.IndexOf(":") + 1)));
            }
            else if (attribute == 2)
            {
                return temp.Substring(temp.LastIndexOf(":") + 1, (temp.Length - (temp.LastIndexOf(":") + 1))); 
            }
            else
            {
                return "NO DATA";
            }
        }

        public void set_Channel_Information(string type, int index, int attribute, string newValue)
        {
            MOD = true;

            if (type == "Sources")
            {
                //format Channel Name:IP:Port
                if (attribute == 0)
                {
                    SRC_CHANNELS[index] =  newValue + SRC_CHANNELS[index].Substring(SRC_CHANNELS[index].IndexOf(":"), SRC_CHANNELS[index].Length);
                }
                else if (attribute == 1)
                {
                    SRC_CHANNELS[index] = SRC_CHANNELS[index].Substring(0, SRC_CHANNELS[index].IndexOf(":")) + newValue
                        + SRC_CHANNELS[index].Substring(SRC_CHANNELS[index].LastIndexOf(":"), SRC_CHANNELS[index].Length - SRC_CHANNELS[index].LastIndexOf(":"));
                }
                else if (attribute == 2)
                {
                    SRC_CHANNELS[index] = SRC_CHANNELS[index].Substring(0, SRC_CHANNELS[index].LastIndexOf(":")) + newValue;
                }
            }
            else if (type == "Destinations")
            {
                //format Channel Name:IP:Port
                if (attribute == 0)
                {
                    //
                    DEST_CHANNELS[index] = newValue + DEST_CHANNELS[index].Substring(DEST_CHANNELS[index].IndexOf(":"), DEST_CHANNELS[index].Length);
                }
                else if (attribute == 1)
                {
                    //
                    DEST_CHANNELS[index] = DEST_CHANNELS[index].Substring(0, DEST_CHANNELS[index].IndexOf(":")) + newValue
                        + DEST_CHANNELS[index].Substring(DEST_CHANNELS[index].LastIndexOf(":"), DEST_CHANNELS[index].Length - DEST_CHANNELS[index].LastIndexOf(":"));
                }
                else if (attribute == 2)
                {
                    //
                    DEST_CHANNELS[index] = DEST_CHANNELS[index].Substring(0, DEST_CHANNELS[index].LastIndexOf(":")) + newValue;
                }
            }
        }

        public bool add_Channel(string type, string name, string IP, int Port)
        {
            MOD = true;

            if (type == "Sources")
            {
                //check if already exists if so then just replace properties
                bool exists = false;
                int index = 0;

                foreach (String str in SRC_CHANNELS)
                {
                    if (str.Contains(name))
                    {
                        exists = true;
                        break;
                    }
                    index++;
                }

                if (exists)
                {
                    //if it already exists then change its attributes
                    SRC_CHANNELS[index] = SRC_CHANNELS[index].Substring(0, SRC_CHANNELS[index].IndexOf(":") + 1) + IP + ":" + Port;
                    return false;
                }
                else
                {
                    SRC_CHANNELS.Add(name + ":" + IP + ":" + Port);
                    return true;
                }
            }
            else if (type == "Destinations")
            {
                //check if already exists if so then just replace properties
                bool exists = false;
                int index = 0;

                foreach (String str in DEST_CHANNELS)
                {
                    if (str.Contains(name))
                    {
                        exists = true;
                        break;
                    }
                    index++;
                }

                if (exists)
                {
                    //if it already exists then change its attributes
                    DEST_CHANNELS[index] = DEST_CHANNELS[index].Substring(0, DEST_CHANNELS[index].IndexOf(":") + 1) + IP + ":" + Port;
                    return false;
                }
                else
                {
                    DEST_CHANNELS.Add(name + ":" + IP + ":" + Port);
                    return true;
                }
            }
            return false;
        }

        public void Save_Data()
        {
            File.WriteAllLines(@"chsrcs.can", SRC_CHANNELS.ToArray());
            File.WriteAllLines(@"chdest.can", DEST_CHANNELS.ToArray());
        }

        public int Number_of_Channels(string type)
        {
            //
            if (type == "Sources")
            {
                return SRC_CHANNELS.Count;
            }
            else if (type == "Destinations")
            {
                return DEST_CHANNELS.Count;
            }
            else
            {
                return 0;
            }
        }

        public void Remove_Channel(string type, int index)
        {
            MOD = true;

            if (type == "Sources")
            {
                SRC_CHANNELS.RemoveAt(index);
            }
            else if (type == "Destinations")
            {
                DEST_CHANNELS.RemoveAt(index);
            }
        }
    }
}
