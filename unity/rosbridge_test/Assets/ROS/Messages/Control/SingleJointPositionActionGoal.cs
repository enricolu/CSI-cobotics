/*
Header header
actionlib_msgs/GoalID goal_id
SingleJointPositionGoal goal
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionActionGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionActionGoal";

        public Header header;
        public GoalID goal_id;
        public SingleJointPositionGoal goal;

        public SingleJointPositionActionGoal()
        {
            header = new Header();
            goal_id = new GoalID();
            goal = new SingleJointPositionGoal();
        }
    }
}

