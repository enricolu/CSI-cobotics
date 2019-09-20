/*
uint8 data
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Uint8 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Unit8";

        public int data;

        public Uint8()
        {
            data = new int();
        }
    }
}

