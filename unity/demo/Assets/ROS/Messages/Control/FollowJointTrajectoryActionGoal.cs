/*
Header header
actionlib_msgs/GoalID goal_id
FollowJointTrajectoryGoal goal
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class FollowJointTrajectoryActionGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/FollowJointTrajectoryActionGoal";

        public Header header;
        public GoalID goal_id;
        public FollowJointTrajectoryGoal goal;

        public FollowJointTrajectoryActionGoal()
        {
            header = new Header();
            goal_id = new GoalID();
            goal = new FollowJointTrajectoryGoal();
        }
    }
}

