/*
# A list of joints in the kinematic tree
string[] joint_names
# A list of joint limits corresponding to the joint names
moveit_msgs/JointLimits[] limits
# A list of links that the kinematics node provides solutions for
string[] link_names
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class KinematicSolverInfo : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/KinematicSolverInfo";

        public String[] joint_names;
        public JointLimits[] limits;
        public String[] link_names;

        public KinematicSolverInfo()
        {
            joint_names = new String[] { };
            limits = new JointLimits[] { };
            link_names = new String[] { };
        }
    }
}

