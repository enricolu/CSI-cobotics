/*
# Each trajectory point specifies either positions[, velocities[, accelerations]]
# or positions[, effort] for the trajectory to be executed.
# All specified values are in the same order as the joint names in JointTrajectory.msg

float64[] positions
float64[] velocities
float64[] accelerations
float64[] effort
duration time_from_start
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Trajectory
{
    public class JointTrajectoryPoint : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "trajectory_msgs/JointTrajectoryPoint";

        public Float64[] positions;
        public Float64[] velocities;
        public Float64[] accelerations;
        public Float64[] effort;
        public Duration time_from_start;

        // Create an unpopulated message
        public JointTrajectoryPoint()
        {
            positions = new Float64[] { };
            velocities = new Float64[] { };
            accelerations = new Float64[] { };
            effort = new Float64[] { };
            time_from_start = new Duration();
        }
    }
}

