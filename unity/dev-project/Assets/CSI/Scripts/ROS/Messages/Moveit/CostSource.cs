/*
# The density of the cost source
float64 cost_density

# The volume of the cost source is represented as an
# axis-aligned bounding box (AABB)
# The AABB is specified by two of its opposite corners

geometry_msgs/Vector3 aabb_min

geometry_msgs/Vector3 aabb_max
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class CostSource : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/CostSource";

        public Float64 cost_density;
        public Vector3 aabb_min;
        public Vector3 aabb_max;

        public CostSource()
        {
            cost_density = new Float64();
            aabb_min = new Vector3();
            aabb_max = new Vector3();
        }
    }
}

