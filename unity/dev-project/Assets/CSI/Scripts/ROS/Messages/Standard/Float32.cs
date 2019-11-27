using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Float32 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Float32";
        public double data;

        public Float32()
        {
            data = 0.0;
        }
    }
}
