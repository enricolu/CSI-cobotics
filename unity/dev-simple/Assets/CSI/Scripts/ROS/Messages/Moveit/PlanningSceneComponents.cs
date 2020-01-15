/*
# This message defines the components that make up the PlanningScene message.
# The values can be used as a bitfield to specify which parts of the PlanningScene message
# are of interest

# Scene name, model name, model root
uint32 SCENE_SETTINGS=1

# Joint values of the robot state
uint32 ROBOT_STATE=2

# Attached objects (including geometry) for the robot state
uint32 ROBOT_STATE_ATTACHED_OBJECTS=4

# The names of the world objects
uint32 WORLD_OBJECT_NAMES=8

# The geometry of the world objects
uint32 WORLD_OBJECT_GEOMETRY=16

# The maintained octomap 
uint32 OCTOMAP=32

# The maintained list of transforms
uint32 TRANSFORMS=64

# The allowed collision matrix
uint32 ALLOWED_COLLISION_MATRIX=128

# The default link padding and link scaling
uint32 LINK_PADDING_AND_SCALING=256

# The stored object colors
uint32 OBJECT_COLORS=512

# Bitfield combining options indicated above
uint32 components
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class PlanningSceneComponents : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PlanningSceneComponents";

        public Uint32 SCENE_SETTINGS;
        public Uint32 ROBOT_STATE;
        public Uint32 ROBOT_STATE_ATTACHED_OBJECTS;
        public Uint32 WORLD_OBJECT_NAMES;
        public Uint32 WORLD_OBJECT_GEOMETRY;
        public Uint32 OCTOMAP;
        public Uint32 TRANSFORMS;
        public Uint32 ALLOWED_COLLISION_MATRIX;
        public Uint32 LINK_PADDING_AND_SCALING;
        public Uint32 OBJECT_COLORS;
        public Uint32 components;

        public PlanningSceneComponents()
        {
            SCENE_SETTINGS = new Uint32();
            SCENE_SETTINGS.data = 1;

            ROBOT_STATE = new Uint32();
            ROBOT_STATE.data = 2;

            ROBOT_STATE_ATTACHED_OBJECTS = new Uint32();
            ROBOT_STATE_ATTACHED_OBJECTS.data = 4;

            WORLD_OBJECT_NAMES = new Uint32();
            WORLD_OBJECT_NAMES.data = 8;

            WORLD_OBJECT_GEOMETRY = new Uint32();
            WORLD_OBJECT_GEOMETRY.data = 16;

            OCTOMAP = new Uint32();
            OCTOMAP.data = 32;

            TRANSFORMS = new Uint32();
            TRANSFORMS.data = 64;

            ALLOWED_COLLISION_MATRIX = new Uint32();
            ALLOWED_COLLISION_MATRIX.data = 128;

            LINK_PADDING_AND_SCALING = new Uint32();
            LINK_PADDING_AND_SCALING.data = 256;

            OBJECT_COLORS = new Uint32();
            OBJECT_COLORS.data = 512;

            components = new Uint32();
        }
    }
}
