/*
# This message contains information about limits of a particular joint (or control dimension)
string joint_name

# true if the joint has position limits
bool has_position_limits

# min and max position limits
float64 min_position
float64 max_position

# true if joint has velocity limits
bool has_velocity_limits

# max velocity limit
float64 max_velocity
# min_velocity is assumed to be -max_velocity

# true if joint has acceleration limits
bool has_acceleration_limits
# max acceleration limit
float64 max_acceleration
# min_acceleration is assumed to be -max_acceleration
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class JointLimits : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/JointLimits";

        public String joint_name;
        public Bool has_position_limits;
        public Float64 min_position;
        public Float64 max_position;
        public Bool has_velocity_limits;
        public Float64 max_velocity;
        public Bool has_acceleration_limits;
        public Float64 max_acceleration;

        public JointLimits()
        {
            joint_name = new String();
            has_position_limits = new Bool();
            min_position = new Float64();
            max_position = new Float64();
            has_velocity_limits = new Bool();
            max_velocity = new Float64();
            has_acceleration_limits = new Bool();
            max_acceleration = new Float64();
        }
    }
}

