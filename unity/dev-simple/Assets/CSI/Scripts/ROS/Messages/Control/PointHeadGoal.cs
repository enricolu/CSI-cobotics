/*
geometry_msgs/PointStamped target
geometry_msgs/Vector3 pointing_axis
string pointing_frame
duration min_duration
float64 max_velocity
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Control
{
    public class PointHeadGoal : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PointHeadGoal";

        public PointStamped target;
        public Vector3 pointing_axis;
        public String pointing_frame;
        public Duration min_duration;
        public Float64 max_velocity;

        public PointHeadGoal()
        {
            target = new PointStamped();
            pointing_axis = new Vector3();
            pointing_frame = new String();
            min_duration = new Duration();
            max_velocity = new Float64();
        }
    }
}

