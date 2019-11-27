/*
 * 
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class String : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/String";
        public string data;

        public String()
        {
            data = "";
        }
    }
}