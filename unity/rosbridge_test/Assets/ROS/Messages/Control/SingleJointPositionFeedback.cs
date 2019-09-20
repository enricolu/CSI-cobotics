/*
Header header
float64 position
float64 velocity
float64 error
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionFeedback";

        public Header header;
        public Float64 position;
        public Float64 velocity;
        public Float64 error;

        public SingleJointPositionFeedback()
        {
            header = new Header();
            position = new Float64();
            velocity = new Float64();
            error = new Float64();
        }
    }
}

