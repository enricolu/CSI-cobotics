/*  
# This represents a vector in free space. 

float64 x
float64 y
float64 z
*/


using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    // This represents a vector in free space. 
    public class Vector3 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Vector3";

        public Float64 x;
        public Float64 y;
        public Float64 z;

        // Create an unpopulated message
        public Vector3()
        {
            x = new Float64();
            y = new Float64();
            z = new Float64();
        }
    }
}