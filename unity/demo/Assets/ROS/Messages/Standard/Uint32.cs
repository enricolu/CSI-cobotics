using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Uint32 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Uint32";
        public int data;

        public Uint32()
        {
            data = 0;
        }
    }
}

