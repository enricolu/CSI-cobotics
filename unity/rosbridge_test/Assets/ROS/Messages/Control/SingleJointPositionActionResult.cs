/*
Header header
actionlib_msgs/GoalStatus status
SingleJointPositionResult result
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionActionResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionActionResult";

        public Header header;
        public GoalStatus status;
        public SingleJointPositionResult result;

        public SingleJointPositionActionResult()
        {
            header = new Header();
            status = new GoalStatus();
            result = new SingleJointPositionResult();
        }
    }
}

