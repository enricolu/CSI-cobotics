/*
trajectory_msgs/JointTrajectory joint_trajectory
trajectory_msgs/MultiDOFJointTrajectory multi_dof_joint_trajectory
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Trajectory;

namespace CSI.ROS.Messages.Moveit
{
    public class RobotTrajectory : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/RobotTrajectory";

        public JointTrajectory joint_trajectory;
        public MultiDOFJointTrajectory multi_dof_joint_trajectory;

        public RobotTrajectory()
        {
            joint_trajectory = new JointTrajectory();
            multi_dof_joint_trajectory = new MultiDOFJointTrajectory();
        }
    }
}

