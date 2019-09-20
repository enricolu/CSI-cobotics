/*
 * int8 data
 */

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Int8 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/int8";

        public int data;

        public Int8()
        {
            data = new int();
        }
    }
}
