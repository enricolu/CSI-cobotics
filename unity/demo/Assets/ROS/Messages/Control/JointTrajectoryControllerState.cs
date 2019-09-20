/*
Header header
string[] joint_names
trajectory_msgs/JointTrajectoryPoint desired
trajectory_msgs/JointTrajectoryPoint actual
trajectory_msgs/JointTrajectoryPoint error  # Redundant, but useful
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Trajectory;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryControllerState : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryControllerState";

        public Header header;
        public String[] joint_names;
        public JointTrajectoryPoint desired;
        public JointTrajectoryPoint actual;
        public JointTrajectoryPoint error;

        public JointTrajectoryControllerState()
        {
            header = new Header();
            joint_names = new String[] { };
            desired = new JointTrajectoryPoint();
            actual = new JointTrajectoryPoint();
            error = new JointTrajectoryPoint();
        }
    }
}
