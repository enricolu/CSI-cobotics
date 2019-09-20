/*
# This represents an orientation in free space in quaternion form.

float64 x
float64 y
float64 z
float64 w
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Geometry
{
    public class Quaternion : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Quaternion";

        public float x;
        public float y;
        public float z;
        public float w;

        // Create an unpopulated message
        public Quaternion()
        {
            x = new float();
            y = new float();
            z = new float();
            w = new float();
        }
    }
}