/*
Header header
actionlib_msgs/GoalID goal_id
PointHeadGoal goal
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadActionGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadActionGoal";

        public Header header;
        public GoalID goal_id;
        public PointHeadGoal goal;

        public PointHeadActionGoal()
        {
            header = new Header();
            goal_id = new GoalID();
            goal = new PointHeadGoal();
        }
    }
}

