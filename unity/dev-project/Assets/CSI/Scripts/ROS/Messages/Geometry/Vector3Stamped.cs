/*
# This represents a Vector3 with reference coordinate frame and timestamp
Header header
Vector3 vector
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class Vector3Stamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Vector3Stamped";
        public Header header;
        public Vector3 vector;

        public Vector3Stamped()
        {
            header = new Header();
            vector = new Vector3();
        }
    }
}
