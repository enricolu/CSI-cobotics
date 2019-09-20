/*
Header header
actionlib_msgs/GoalID goal_id
JointTrajectoryGoal goal
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryActionGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryActionGoal";

        public Header header;
        public GoalID goal_id;
        public JointTrajectoryGoal goal;

        public JointTrajectoryActionGoal()
        {
            header = new Header();
            goal_id = new GoalID();
            goal = new JointTrajectoryGoal();
        }
    }
}

