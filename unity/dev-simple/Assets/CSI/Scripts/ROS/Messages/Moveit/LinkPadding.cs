/*
#name for the link
string link_name

# padding to apply to the link
float64 padding
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class LinkPadding : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/LinkPadding";

        public String link_name;
        public Float64 padding;

        public LinkPadding()
        {
            link_name = new String();
            padding = new Float64();
        }
    }
}

