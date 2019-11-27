/*
PointHeadActionGoal action_goal
PointHeadActionResult action_result
PointHeadActionFeedback action_feedback
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadAction : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadAction";

        public PointHeadActionGoal action_goal;
        public PointHeadActionResult action_result;
        public PointHeadActionFeedback action_feedback;

        public PointHeadAction()
        {
            action_goal = new PointHeadActionGoal();
            action_result = new PointHeadActionResult();
            action_feedback = new PointHeadActionFeedback();
        }
    }
}
