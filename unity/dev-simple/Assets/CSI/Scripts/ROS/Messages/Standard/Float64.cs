/*

*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class Float64 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Float64";
        public double data;

        public Float64()
        {
            data = 0.0;
        }
    }
}