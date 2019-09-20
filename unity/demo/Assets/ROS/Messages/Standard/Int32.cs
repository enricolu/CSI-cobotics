/*
int32 data
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Int32 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Int32";

        public int data;

        public Int32()
        {
            data = new int();
        }
    }
}

