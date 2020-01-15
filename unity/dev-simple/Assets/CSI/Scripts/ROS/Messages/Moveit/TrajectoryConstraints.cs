/*
# The array of constraints to consider along the trajectory
Constraints[] constraints
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Moveit
{
    public class TrajectoryConstraints : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/TrajectoryConstraints";

        public Constraints[] constraints;

        public TrajectoryConstraints()
        {
            constraints = new Constraints[] { };
        }
    }
}
