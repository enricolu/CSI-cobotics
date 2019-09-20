/*
# A twist with reference coordinate frame and timestamp
Header header
Twist twist
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class TwistStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/TwistStamped";

        public Header header;
        public Twist twist;

        public TwistStamped()
        {
            header = new Header();
            twist = new Twist();
        }
    }
}