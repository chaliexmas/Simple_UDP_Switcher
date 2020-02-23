using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace Simple_Switcher
{
    public class Channels_Manager
    {
        /* Resposibilities:
         * create a default xml document if one doesnt exist 
         * edit values in the xml file 
         * access values in the xml file 
         */

        //core components
        private XmlDocument channels_doc;
        private XmlNodeList nodes;

        public int number_of_Src_Channels = 0;
        public int number_of_Dest_Channels = 0;

        ~Channels_Manager()
        {
            //close things down
        }

        //constructor checks for an existing file,  if not found creates a default one
        public Channels_Manager()
        {
            //check if file does not exist
            if (!File.Exists("Channel_Data.xml"))
            {
                //create the file
                XmlTextWriter channel_data = new XmlTextWriter("Channel_Data.xml", null);
                channel_data.Formatting = Formatting.Indented;
                channel_data.WriteStartDocument();
                
                //Write all channel data
                channel_data.WriteStartElement("Channel_Data");

                //write the sources
                channel_data.WriteStartElement("Sources");
                channel_data.WriteAttributeString("Channels", "1");
                    channel_data.WriteStartElement("Input_1");
                    channel_data.WriteAttributeString("Name", "Input #1");
                    channel_data.WriteAttributeString("IP", "239.16.33.11");
                    channel_data.WriteAttributeString("Port", "8901");
                    channel_data.WriteEndElement();
                channel_data.WriteEndElement();

                //write the destinations
                channel_data.WriteStartElement("Destinations");
                channel_data.WriteAttributeString("Channels", "1");
                    channel_data.WriteStartElement("Output_1");
                    channel_data.WriteAttributeString("Name", "Output #1");
                    channel_data.WriteAttributeString("IP", "239.16.33.11");
                    channel_data.WriteAttributeString("Port", "8902");
                    channel_data.WriteEndElement();
                channel_data.WriteEndElement();

                channel_data.WriteEndElement();

                //end the document
                channel_data.WriteEndDocument();
                channel_data.Flush();
                channel_data.Close();
            }

            //
            channels_doc = new XmlDocument();
            channels_doc.Load("Channel_Data.xml");

            //retrive the number of channels
            nodes = channels_doc.GetElementsByTagName("Sources");
            number_of_Src_Channels = Convert.ToInt32(nodes[0].Attributes[0].Value.ToString());

            nodes = channels_doc.GetElementsByTagName("Destinations");
            number_of_Dest_Channels = Convert.ToInt32(nodes[0].Attributes[0].Value.ToString());
        }

        //get all channel names according to type (Sources or Destinations)
        //then retrive the name according to the index
        public string get_Channel_Information(string type, int index, int attribute)
        {
            //node structure hirearchy
            nodes = channels_doc.GetElementsByTagName(type);
            return (nodes[0].ChildNodes[index].Attributes[attribute].Value.ToString());
        }

        //
        public void set_Channel_Information(string type, int index, int attribute, string newValue)
        {
            //get the location of the type
            nodes = channels_doc.GetElementsByTagName(type);
            //modify the value of the type at the attribute specified
            nodes[0].ChildNodes[index].Attributes[attribute].Value = newValue;
            //make sure to save the changes
            channels_doc.Save("Channel_Data.xml");
        }

        public void add_Channel(string type, string name, string IP, int Port)
        {
            //get node at location
            nodes = channels_doc.GetElementsByTagName(type);

            //increment the channel counter in each section
            if (type.Equals("Sources"))
            {
                number_of_Src_Channels++;
                nodes[0].Attributes[0].Value = number_of_Src_Channels.ToString();
            }
            else if (type.Equals("Destinations"))
            {
                number_of_Dest_Channels++;
                nodes[0].Attributes[0].Value = number_of_Dest_Channels.ToString();
            }
            else
            {
                //wrong value
                return;
            }

            //Create the element and add it
            XmlElement elem = channels_doc.CreateElement("Input_" + nodes[0].Attributes[0].Value.ToString());
            
            //attach its attributes
            elem.SetAttribute("Name", name);
            elem.SetAttribute("IP", IP);
            elem.SetAttribute("Port", Port.ToString());

            //Append it to the file
            nodes[0].AppendChild(elem);

            //save the changes
            channels_doc.Save("Channel_Data.xml");
        }

        public void remove_Channel(string type, string name)
        {
            //
            nodes = channels_doc.GetElementsByTagName(type);

            //get the amount of channels
            int numberofChannels = Convert.ToInt32(nodes[0].Attributes[0].Value.ToString());
            
            //check if no channels present if 0 then dont do anything
            if (numberofChannels > 0)
            {
                //remove the element
                for (int i = 0; i < numberofChannels; i++)
                {
                    if (nodes[0].ChildNodes[i].Attributes[0].Value.ToString().Equals(name))
                    {
                        //remove from the file
                        nodes[0].RemoveChild(nodes[0].ChildNodes[i]);

                        //decrement the channel counter in each section (xml)
                        numberofChannels--;

                        //update the attribute
                        nodes[0].Attributes[0].Value = numberofChannels.ToString();

                        //increment the channel counter in each section
                        if (type.Equals("Sources"))
                        {
                            number_of_Src_Channels--;
                        }
                        else if (type.Equals("Destinations"))
                        {
                            number_of_Dest_Channels--;
                        }

                        //save the changes
                        channels_doc.Save("Channel_Data.xml");
                    }
                }
            }
        }//

    }
}
