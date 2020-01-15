/*
Header header
actionlib_msgs/GoalStatus status
PointHeadFeedback feedback
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadActionFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadActionFeedback";

        public Header header;
        public GoalStatus status;
        public PointHeadFeedback feedback;

        public PointHeadActionFeedback()
        {
            header = new Header();
            status = new GoalStatus();
            feedback = new PointHeadFeedback();
        }
    }
}

