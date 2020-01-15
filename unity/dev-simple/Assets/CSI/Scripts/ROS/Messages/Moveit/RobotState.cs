/*
# This message contains information about the robot state, i.e. the positions of its joints and links
sensor_msgs/JointState joint_state

# Joints that may have multiple DOF are specified here
sensor_msgs/MultiDOFJointState multi_dof_joint_state

# Attached collision objects (attached to some link on the robot)
AttachedCollisionObject[] attached_collision_objects

# Flag indicating whether this scene is to be interpreted as a diff with respect to some other scene
# This is mostly important for handling the attached bodies (whether or not to clear the attached bodies
# of a moveit::core::RobotState before updating it with this message)
bool is_diff
*/


using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Sensor;

namespace CSI.ROS.Messages.Moveit
{
    public class RobotState : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/RobotState";

        public JointState joint_state;
        public MultiDOFJointState multi_dof_joint_state;
        public AttachedCollisionObject[] attached_collision_objects;
        public Bool is_diff;

        public RobotState()
        {
            joint_state = new JointState();
            multi_dof_joint_state = new MultiDOFJointState();
            attached_collision_objects = new AttachedCollisionObject[] { };
            is_diff = new Bool();
        }
    }
}
