/*
# This message contains the definition of an orientation constraint.

Header header

# The desired orientation of the robot link specified as a quaternion
geometry_msgs/Quaternion orientation

# The robot link this constraint refers to
string link_name

# optional axis-angle error tolerances specified
float64 absolute_x_axis_tolerance
float64 absolute_y_axis_tolerance
float64 absolute_z_axis_tolerance

# A weighting factor for this constraint (denotes relative importance to other constraints. Closer to zero means less important)
float64 weight
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class OrientationConstraint : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/OrientationConstraint";

        public Header header;
        public Quaternion orientation;
        public String link_name;
        public Float64 absolute_x_axis_tolerance;
        public Float64 absolute_y_axis_tolerance;
        public Float64 absolute_z_axis_tolerance;
        public Float64 weight;

        public OrientationConstraint()
        {
            header = new Header();
            orientation = new Quaternion();
            link_name = new String();
            absolute_x_axis_tolerance = new Float64();
            absolute_y_axis_tolerance = new Float64();
            absolute_z_axis_tolerance = new Float64();
            weight = new Float64();
        }
    }
}

