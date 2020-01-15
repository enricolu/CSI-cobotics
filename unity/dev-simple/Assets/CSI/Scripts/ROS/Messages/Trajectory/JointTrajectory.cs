/*
This message class is generated automatically with 'SimpleMessageGenerator' of ROS#
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Trajectory
{
    public class JointTrajectory : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "trajectory_msgs/JointTrajectory";

        public Header header;
        public String[] joint_names;
        public JointTrajectoryPoint[] points;

        // Create an unpopulated message
        public JointTrajectory()
        {
            joint_names = new String[] { };
            points = new JointTrajectoryPoint[] { };
        }
    }
}