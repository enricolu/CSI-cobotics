/*
# This expresses velocity in free space broken into it's linear and angular parts. 
Vector3 linear
Vector3 angular
*/

using Newtonsoft.Json;
using CSI.ROS.Messages;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    // This represents a vector in free space. 
    public class Twist : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Twist";

        public Vector3 linear;
        public Vector3 angular;

        // Create an unpopulated message
        public Twist()
        {
            linear = new Vector3();
            angular = new Vector3();
        }
    }
}
