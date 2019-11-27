

using Newtonsoft.Json;
using CSI.ROS.Messages.Trajectory;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryFeedback";

        public JointTrajectoryFeedback()
        {
            // Contains no members
        }
    }
}

