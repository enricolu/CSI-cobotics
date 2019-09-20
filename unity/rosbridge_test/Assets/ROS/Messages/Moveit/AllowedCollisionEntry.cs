/*
# whether or not collision checking is enabled
bool[] enabled
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class AllowedCollisionEntry : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/AllowedCollisionEntry";

        public Bool[] enabled;

        public AllowedCollisionEntry()
        {
            enabled = new Bool[] { };
        }
    }
}

