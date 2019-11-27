/*
Header header
actionlib_msgs/GoalStatus status
PointHeadResult result
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadActionResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadActionResult";

        public Header header;
        public GoalStatus status;
        public PointHeadResult result;

        public PointHeadActionResult()
        {
            header = new Header();
            status = new GoalStatus();
            result = new PointHeadResult();
        }
    }
}

