using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Bool : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Bool";

        public bool data;

        public Bool()
        {
            data = new bool();
        }
    }
}
