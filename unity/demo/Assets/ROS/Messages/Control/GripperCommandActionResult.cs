/*
Header header
actionlib_msgs/GoalStatus status
GripperCommandResult result
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class GripperCommandActionResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/GripperCommandActionResult";

        public Header header;
        public GoalStatus status;
        public GripperCommandResult result;

        public GripperCommandActionResult()
        {
            header = new Header();
            status = new GoalStatus();
            result = new GripperCommandResult();
        }
    }
}

