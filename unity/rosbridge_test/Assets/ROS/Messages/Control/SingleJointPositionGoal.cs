/*
float64 position
duration min_duration
float64 max_velocity
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class SingleJointPositionGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/SingleJointPositionGoal";

        public Float64 position;
        public Duration min_duration;
        public Float64 max_velocity;

        public SingleJointPositionGoal()
        {
            position = new Float64();
            min_duration = new Duration();
            max_velocity = new Float64();
        }
    }
}

