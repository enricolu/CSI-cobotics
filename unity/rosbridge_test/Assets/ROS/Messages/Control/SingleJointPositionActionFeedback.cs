/*
Header header
actionlib_msgs/GoalStatus status
SingleJointPositionFeedback feedback
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionActionFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionActionFeedback";

        public Header header;
        public GoalStatus status;
        public SingleJointPositionFeedback feedback;

        public SingleJointPositionActionFeedback()
        {
            header = new Header();
            status = new GoalStatus();
            feedback = new SingleJointPositionFeedback();
        }
    }
}

