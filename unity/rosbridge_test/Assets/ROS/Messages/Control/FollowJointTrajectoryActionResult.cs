/*
Header header
actionlib_msgs/GoalStatus status
FollowJointTrajectoryResult result
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class FollowJointTrajectoryActionResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/FollowJointTrajectoryActionResult";

        public Header header;
        public GoalStatus status;
        public FollowJointTrajectoryResult result;

        public FollowJointTrajectoryActionResult()
        {
            header = new Header();
            status = new GoalStatus();
            result = new FollowJointTrajectoryResult();
        }
    }
}

