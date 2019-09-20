/*
# This represents an orientation in free space in quaternion form.

float64 x
float64 y
float64 z
float64 w
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class Quaternion : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Quaternion";

        public Float64 x;
        public Float64 y;
        public Float64 z;
        public Float64 w;

        // Create an unpopulated message
        public Quaternion()
        {
            x = new Float64();
            y = new Float64();
            z = new Float64();
            w = new Float64();
        }
    }
}