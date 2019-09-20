/*
# This message contains the definition of a position constraint.

Header header

# The robot link this constraint refers to
string link_name

# The offset (in the link frame) for the target point on the link we are planning for
geometry_msgs/Vector3 target_point_offset

# The volume this constraint refers to 
BoundingVolume constraint_region

# A weighting factor for this constraint (denotes relative importance to other constraints. Closer to zero means less important)
float64 weight
*/


using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class PositionConstraint : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PositionConstraint";

        public Header header;
        public String link_name;
        public Vector3 target_point_offset;
        public BoundingVolume constraint_region;
        public Float64 weight;

        public PositionConstraint()
        {
            header = new Header();
            link_name = new String();
            target_point_offset = new Vector3();
            constraint_region = new BoundingVolume();
            weight = new Float64();
        }
    }
}