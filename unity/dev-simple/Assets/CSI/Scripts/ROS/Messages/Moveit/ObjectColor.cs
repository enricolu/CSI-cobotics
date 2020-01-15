/*
# The object id for which we specify color
string id

# The value of the color
std_msgs/ColorRGBA color
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class ObjectColor : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/ObjectColor";

        public String id;
        public ColorRGBA color;

        public ObjectColor()
        {
            id = new String();
            color = new ColorRGBA();
        }
    }
}

