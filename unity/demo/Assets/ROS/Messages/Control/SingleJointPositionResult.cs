/*

*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionResult";
        
        public SingleJointPositionResult()
        {
            // Empty
        }
    }
}

