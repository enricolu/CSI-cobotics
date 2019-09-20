/*
Header header
actionlib_msgs/GoalStatus status
GripperCommandFeedback feedback
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class GripperCommandActionFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/GripperCommandActionFeedback";

        public Header header;
        public GoalStatus status;
        public GripperCommandFeedback feedback;

        public GripperCommandActionFeedback()
        {
            header = new Header();
            status = new GoalStatus();
            feedback = new GripperCommandFeedback();
        }
    }
}

