/*
# A representation of pose in free space, composed of postion and orientation. 
Point position
Quaternion orientation
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Geometry
{
    public class Pose : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Pose";

        public Point position;
        public Quaternion orientation;

        // Create an unpopulated message
        public Pose()
        {
            position = new Point();
            orientation = new Quaternion();
        }
    }
}