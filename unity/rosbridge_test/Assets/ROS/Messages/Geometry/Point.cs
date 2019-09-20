/*
# This contains the position of a point in free space
float64 x
float64 y
float64 z
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Geometry
{
    public class Point : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Point";

        public float x;
        public float y;
        public float z;

        // Create an unpopulated message
        public Point() { }        
    }
}

/*
x = new Float64();
y = new Float64();
z = new Float64();
*/