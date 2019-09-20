/*
# name of planning scene
string name

# full robot state
RobotState robot_state

# The name of the robot model this scene is for
string robot_model_name

#additional frames for duplicating tf (with respect to the planning frame)
geometry_msgs/TransformStamped[] fixed_frame_transforms

#full allowed collision matrix
AllowedCollisionMatrix allowed_collision_matrix

# all link paddings
LinkPadding[] link_padding

# all link scales
LinkScale[] link_scale

# Attached objects, collision objects, even the octomap or collision map can have 
# colors associated to them. This array specifies them.
ObjectColor[] object_colors

# the collision map
PlanningSceneWorld world

# Flag indicating whether this scene is to be interpreted as a diff with respect to some other scene
bool is_diff
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class PlanningScene : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PlanningScene";

        public String name;
        public RobotState robot_state;
        public String robot_model_name;
        public TransformStamped[] fixed_frame_transforms;
        public AllowedCollisionMatrix allowed_collision_matrix;
        public LinkPadding[] link_padding;
        public LinkScale[] link_scale;
        public ObjectColor[] object_colors;
        public PlanningSceneWorld world;
        public Bool is_diff;

        public PlanningScene()
        {
            name = new String();
            robot_state = new RobotState();
            robot_model_name = new String();
            fixed_frame_transforms = new TransformStamped[] { };
            allowed_collision_matrix = new AllowedCollisionMatrix();
            link_padding = new LinkPadding[] { };
            link_scale = new LinkScale[] { };
            object_colors = new ObjectColor[] { };
            world = new PlanningSceneWorld { };
            is_diff = new Bool();
        }
    }
}
