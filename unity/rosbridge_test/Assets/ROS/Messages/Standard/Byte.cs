/*
byte data
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Byte : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Byte";

        public byte data;

        public Byte()
        {
            data = new byte();
        }
    }
}

