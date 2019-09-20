/*
FollowJointTrajectoryActionGoal action_goal
FollowJointTrajectoryActionResult action_result
FollowJointTrajectoryActionFeedback action_feedback
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class FollowJointTrajectoryAction : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/FollowJointTrajectoryAction";

        public FollowJointTrajectoryActionGoal action_goal;
        public FollowJointTrajectoryActionResult action_result;
        public FollowJointTrajectoryActionFeedback action_feedback;

        public FollowJointTrajectoryAction()
        {
            action_goal = new FollowJointTrajectoryActionGoal();
            action_result = new FollowJointTrajectoryActionResult();
            action_feedback = new FollowJointTrajectoryActionFeedback();
        }
    }
}

