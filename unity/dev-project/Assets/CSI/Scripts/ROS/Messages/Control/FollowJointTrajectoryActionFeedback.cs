/*
Header header
actionlib_msgs/GoalStatus status
FollowJointTrajectoryFeedback feedback
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class FollowJointTrajectoryActionFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/FollowJointTrajectoryActionFeedback";

        public Header header;
        public GoalStatus status;
        public FollowJointTrajectoryFeedback feedback;

        public FollowJointTrajectoryActionFeedback()
        {
            header = new Header();
            status = new GoalStatus();
            feedback = new FollowJointTrajectoryFeedback();
        }
    }
}

