/*
# A name for this grasp
string id

# The internal posture of the hand for the grasp
# positions and efforts are used
trajectory_msgs/JointTrajectory post_place_posture

# The position of the end-effector for the grasp relative to a reference frame 
# (that is always specified elsewhere, not in this message)
geometry_msgs/PoseStamped place_pose

# The approach motion
GripperTranslation pre_place_approach

# The retreat motion
GripperTranslation post_place_retreat

# an optional list of obstacles that we have semantic information about
# and that can be touched/pushed/moved in the course of grasping
string[] allowed_touch_objects
*/
using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Trajectory;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class PlaceLocation : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PlaceLocation";

        public String id;
        public JointTrajectory[] post_place_posture;
        public PoseStamped place_pose;
        public GripperTranslation pre_place_approach;
        public GripperTranslation post_place_retreat;
        public String[] allowed_touch_objects;

        public PlaceLocation()
        {
            id = new String();
            post_place_posture = new JointTrajectory[] { };
            place_pose = new PoseStamped();
            pre_place_approach = new GripperTranslation();
            post_place_retreat = new GripperTranslation();
            allowed_touch_objects = new String[] { };
        }
    }
}
