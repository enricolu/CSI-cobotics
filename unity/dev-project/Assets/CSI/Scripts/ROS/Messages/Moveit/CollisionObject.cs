/*
# a header, used for interpreting the poses
Header header

# the id of the object (name used in MoveIt)
string id

# The object type in a database of known objects
object_recognition_msgs/ObjectType type

# the the collision geometries associated with the object;
# their poses are with respect to the specified header

# solid geometric primitives
shape_msgs/SolidPrimitive[] primitives
geometry_msgs/Pose[] primitive_poses

# meshes
shape_msgs/Mesh[] meshes
geometry_msgs/Pose[] mesh_poses

# bounding planes (equation is specified, but the plane can be oriented using an additional pose)
shape_msgs/Plane[] planes
geometry_msgs/Pose[] plane_poses

# Adds the object to the planning scene. If the object previously existed, it is replaced.
byte ADD=0

# Removes the object from the environment entirely (everything that matches the specified id)
byte REMOVE=1

# Append to an object that already exists in the planning scene. If the does not exist, it is added.
byte APPEND=2

# If an object already exists in the scene, new poses can be sent (the geometry arrays must be left empty)
# if solely moving the object is desired
byte MOVE=3

# Operation to be performed
byte operation
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Shape;
using CSI.ROS.Messages.Geometry;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class CollisionObject : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/CollisionObject";

        public Plane[] planes;
        public Pose[] plane_poses;
        public Byte ADD;
        public Byte REMOVE;
        public Byte APPEND;
        public Byte MOVE;
        public Byte operation;

        public CollisionObject()
        {
            planes = new Plane[] { };
            plane_poses = new Pose[] { };

            ADD = new Byte();
            ADD.data = 0;

            REMOVE = new Byte();
            REMOVE.data = 1;

            APPEND = new Byte();
            APPEND.data = 2;

            MOVE = new Byte();
            MOVE.data = 3;

            operation = new Byte();
        }
    }
}

