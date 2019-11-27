/*
GripperCommand command
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class GripperCommandGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/GripperCommandGoal";

        public GripperCommand command;

        public GripperCommandGoal()
        {
            command = new GripperCommand();
        }
    }
}

