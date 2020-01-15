/*
Header header
actionlib_msgs/GoalStatus status
JointTrajectoryResult result
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryActionResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryActionResult";

        public Header header;
        public GoalStatus status;
        public JointTrajectoryResult result;

        public JointTrajectoryActionResult()
        {
            header = new Header();
            status = new GoalStatus();
            result = new JointTrajectoryResult();
        }
    }
}

