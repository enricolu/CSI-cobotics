/*
This message class is generated automatically with 'SimpleMessageGenerator' of ROS#
*/ 

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Duration : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Duration";

        public int data;

        public Duration()
        {
            data = new int();
        }
    }
}

