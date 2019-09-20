/*
GripperCommandActionGoal action_goal
GripperCommandActionResult action_result
GripperCommandActionFeedback action_feedback
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class GripperCommandAction : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "beginner_tutorials/GripperCommandAction";

        public GripperCommandActionGoal action_goal;
        public GripperCommandActionResult action_result;
        public GripperCommandActionFeedback action_feedback;

        public GripperCommandAction()
        {
            action_goal = new GripperCommandActionGoal();
            action_result = new GripperCommandActionResult();
            action_feedback = new GripperCommandActionFeedback();
        }
    }
}

