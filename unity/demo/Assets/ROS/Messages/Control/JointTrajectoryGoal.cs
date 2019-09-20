/*
trajectory_msgs/JointTrajectory trajectory
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Trajectory;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryGoal";

        public JointTrajectory trajectory;

        public JointTrajectoryGoal()
        {
            trajectory = new JointTrajectory();
        }
    }
}

