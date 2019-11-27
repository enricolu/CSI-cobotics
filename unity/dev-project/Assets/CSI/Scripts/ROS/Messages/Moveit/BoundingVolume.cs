/*
# Define a volume in 3D

# A set of solid geometric primitives that make up the volume to define (as a union)
shape_msgs/SolidPrimitive[] primitives

# The poses at which the primitives are located
geometry_msgs/Pose[] primitive_poses

# In addition to primitives, meshes can be specified to add to the bounding volume (again, as union)
shape_msgs/Mesh[] meshes

# The poses at which the meshes are located
geometry_msgs/Pose[] mesh_poses
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Shape;
using CSI.ROS.Messages.Geometry;


namespace CSI.ROS.Messages.Moveit
{
    public class BoundingVolume : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/BoundingVolume";

        public SolidPrimitive[] primitives;
        public Pose[] primitive_poses;
        public Mesh[] meshes;
        public Pose[] mesh_poses;

        public BoundingVolume()
        {
            primitives = new SolidPrimitive[] { };
            primitive_poses = new Pose[] { };
            meshes = new Mesh[] { };
            mesh_poses = new Pose[] { };
        }
    }
}

