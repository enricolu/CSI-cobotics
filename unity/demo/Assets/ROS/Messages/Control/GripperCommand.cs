/*
float64 position
float64 max_effort
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class GripperCommand : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/GripperCommand";

        public Float64 position;
        public Float64 max_effort;

        // Create an unpopulated message
        public GripperCommand()
        {
            position = new Float64();
            max_effort = new Float64();
        }
    }
}