/*
# Stores the statuses for goals that are currently being tracked
# by an action server
Header header
GoalStatus[] status_list
*/


using Newtonsoft.Json;
using CSI.ROS.Messages;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.ActionLib
{
    public class GoalStatusArray : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "actionlib/GoalStatusArray";

        public Header header;
        public GoalStatus[] status_list;

        // Create an unpopulated message
        public GoalStatusArray()
        {
            header = new Header();
            status_list = new GoalStatus[] { }; 
        }
    }
}

