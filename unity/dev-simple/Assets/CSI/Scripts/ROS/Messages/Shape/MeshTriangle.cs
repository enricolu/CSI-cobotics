/*
# Definition of a triangle's vertices
uint32[3] vertex_indices
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Shape
{
    public class MeshTriangle : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "shape_msgs/MeshTriangle";

        public Uint32[] vertex_indices;

        public MeshTriangle()
        {
            vertex_indices = new Uint32[3];
        }
    }
}

