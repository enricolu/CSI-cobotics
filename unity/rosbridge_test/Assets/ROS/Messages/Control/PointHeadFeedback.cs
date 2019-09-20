/*
float64 pointing_angle_error
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadFeedback";

        public Float64 pointing_angle_error;

        public PointHeadFeedback()
        {
            pointing_angle_error = new Float64();
        }
    }
}

