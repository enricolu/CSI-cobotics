/*

*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadResult";

        public PointHeadResult()
        {
            //Is empty
        }
    }
}

