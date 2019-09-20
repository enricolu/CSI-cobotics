/*
# This represents a Point with reference coordinate frame and timestamp
Header header
Point point
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class PointStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/PointStamped";

        public Header header;
        public Point point;

        public PointStamped()
        {
            header = new Header();
            point = new Point();
        }
    }
}
