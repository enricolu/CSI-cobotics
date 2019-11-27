/*
# The stamp should store the time at which this goal was requested.
# It is used by an action server when it tries to preempt all
# goals that were requested before a certain time
time stamp

# The id provides a way to associate feedback and
# result message with specific goal requests. The id
# specified must be unique.
string id
*/


using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.ActionLib
{
    public class GoalID : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "actionlib/GoalID";

        public Time stamp;
        public string id;

        // Create an unpopulated message
        public GoalID()
        {
            stamp = new Time();
            id = "";
        }
    }
}
