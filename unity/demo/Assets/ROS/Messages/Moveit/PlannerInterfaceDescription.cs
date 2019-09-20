/*
# The name of the planner interface
string name

# The names of the planner ids within the interface
string[] planner_ids
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class PlannerInterfaceDescription : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PlannerInterfaceDescription";

        public String name;
        public String[] planner_ids;

        public PlannerInterfaceDescription()
        {
            name = new String();
            planner_ids = new String[] { };
        }
    }
}
