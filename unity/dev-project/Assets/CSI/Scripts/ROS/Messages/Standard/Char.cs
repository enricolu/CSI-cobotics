/*
char data
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Char : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Char";

        public char data;

        public Char()
        {
            data = new char();
        }
    }
}

