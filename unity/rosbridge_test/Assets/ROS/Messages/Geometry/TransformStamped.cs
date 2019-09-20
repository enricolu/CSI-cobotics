/*  
# This expresses a transform from coordinate frame header.frame_id
# to the coordinate frame child_frame_id
#
# This message is mostly used by the 
# <a href="http://www.ros.org/wiki/tf">tf</a> package. 
# See it's documentation for more information.

Header header
string child_frame_id # the frame id of the child frame
Transform transform
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class TransformStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/TransformStamped";

        public Header header;
        public String child_frame_id;
        public Transform transform;

        public TransformStamped()
        {
            header = new Header();
            child_frame_id = new String();
            transform = new Transform();
        }
    }
}
