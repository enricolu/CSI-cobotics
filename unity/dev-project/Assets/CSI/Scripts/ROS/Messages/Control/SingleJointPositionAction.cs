/*
SingleJointPositionActionGoal action_goal
SingleJointPositionActionResult action_result
SingleJointPositionActionFeedback action_feedback
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionAction : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionAction";

        public SingleJointPositionActionGoal action_goal;
        public SingleJointPositionActionResult action_result;
        public SingleJointPositionActionFeedback action_feedback;

        public SingleJointPositionAction()
        {
            action_goal = new SingleJointPositionActionGoal();
            action_result = new SingleJointPositionActionResult();
            action_feedback = new SingleJointPositionActionFeedback();
        }
    }
}
