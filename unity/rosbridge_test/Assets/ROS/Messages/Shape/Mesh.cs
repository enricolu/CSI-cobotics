/*
# Definition of a mesh

# list of triangles; the index values refer to positions in vertices[]
MeshTriangle[] triangles

# the actual vertices that make up the mesh
geometry_msgs/Point[] vertices
*/

using Newtonsoft.Json;
using RosSharp.RosBridgeClient.Messages.Geometry;


namespace CSI.ROS.Messages.Shape
{
    public class Mesh : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "shape_msgs/Mesh";

        public MeshTriangle[] triangles;
        public Point[] vertices;

        public Mesh()
        {
            triangles = new MeshTriangle[] { };
            vertices = new Point[] { };
        }
    }
}

