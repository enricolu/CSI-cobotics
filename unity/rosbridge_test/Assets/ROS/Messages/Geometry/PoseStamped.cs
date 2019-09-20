/*
# A Pose with reference coordinate frame and timestamp
Header header
Pose pose
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class PoseStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/PoseStamped";
        public Header header;
        public Pose pose;

        public PoseStamped()
        {
            header = new Header();
            pose = new Pose();
        }
    }
}