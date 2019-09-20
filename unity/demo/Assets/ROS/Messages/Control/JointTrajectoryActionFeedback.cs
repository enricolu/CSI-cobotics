/*
Header header
actionlib_msgs/GoalStatus status
JointTrajectoryFeedback feedback
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryActionFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryActionFeedback";

        public Header header;
        public GoalStatus status;
        public JointTrajectoryFeedback feedback;

        public JointTrajectoryActionFeedback()
        {
            header = new Header();
            status = new GoalStatus();
            feedback = new JointTrajectoryFeedback();
        }
    }
}

