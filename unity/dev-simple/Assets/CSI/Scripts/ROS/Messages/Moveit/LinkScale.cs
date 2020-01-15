/*
#name for the link
string link_name

# scaling to apply to the link
float64 scale
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class LinkScale : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/LinkScale";

        public String link_name;
        public Float64 scale;

        public LinkScale()
        {
            link_name = new String();
            scale = new Float64();
        }
    }
}
