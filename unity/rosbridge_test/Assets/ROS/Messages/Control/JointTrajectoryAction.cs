/*
JointTrajectoryActionGoal action_goal
JointTrajectoryActionResult action_result
JointTrajectoryActionFeedback action_feedback
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.ActionLib;

namespace CSI.ROS.Messages.Control
{
    public class JointTrajectoryAction : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTrajectoryAction";

        public JointTrajectoryActionGoal action_goal;
        public JointTrajectoryActionResult action_result;
        public JointTrajectoryActionFeedback action_feedback;


        public JointTrajectoryAction()
        {
            action_goal = new JointTrajectoryActionGoal();
            action_result = new JointTrajectoryActionResult();
            action_feedback = new JointTrajectoryActionFeedback();
        }
    }
}
