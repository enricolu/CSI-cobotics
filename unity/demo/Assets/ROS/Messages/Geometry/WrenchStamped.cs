/*
# A wrench with reference coordinate frame and timestamp
Header header
Wrench wrench
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class WrenchStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/WrenchStamped";

        public Header header;
        public Wrench wrench;

        public WrenchStamped()
        {
            header = new Header();
            wrench = new Wrench();
        }
    }
}

