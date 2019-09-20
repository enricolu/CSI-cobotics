/*
# This contains the position of a point in free space(with 32 bits of precision).
# It is recommeded to use Point wherever possible instead of Point32.  
# 
# This recommendation is to promote interoperability.  
#
# This message is designed to take up less space when sending
# lots of points at once, as in the case of a PointCloud.  

float32 x
float32 y
float32 z
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class Point32 : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Point32";


        public float x;
        public float y;
        public float z;

        public Point32()
        {
            x = new float();
            y = new float();
            z = new float();
        }
    }
}

        /*
        public Float32 x;
        public Float32 y;
        public Float32 z;

        public Point32()
        {
            x = new Float32();
            y = new Float32();
            z = new Float32();
        }
        */