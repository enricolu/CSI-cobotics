/*
float64 position  # The current gripper gap size (in meters)
float64 effort    # The current effort exerted (in Newtons)
bool stalled      # True iff the gripper is exerting max effort and not moving
bool reached_goal # True iff the gripper position has reached the commanded setpoint
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class GripperCommandFeedback : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/GripperCommandFeedback";

        public Float64 position;
        public Float64 effort;
        public Bool stalled;
        public Bool reached_goal;

        public GripperCommandFeedback()
        {
            position = new Float64();
            effort = new Float64();
            stalled = new Bool();
            reached_goal = new Bool();
        }
    }
}

