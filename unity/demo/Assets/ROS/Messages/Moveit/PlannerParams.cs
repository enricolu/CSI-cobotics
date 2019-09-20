/*
# parameter names (same size as values)
string[] keys

# parameter values (same size as keys)
string[] values

# parameter description (can be empty)
string[] descriptions
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class PlannerParams : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PlannerParams";

        public String[] keys;
        public String[] values;
        public String[] descriptions;

        public PlannerParams()
        {
            keys = new String[] { };
            values = new String[] { };
            descriptions = new String[] { };
        }
    }
}

