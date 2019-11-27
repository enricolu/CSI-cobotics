/*
# The tolerances specify the amount the position, velocity, and
# accelerations can vary from the setpoints.  For example, in the case
# of trajectory control, when the actual position varies beyond
# (desired position + position tolerance), the trajectory goal may
# abort.
# 
# There are two special values for tolerances:
#  * 0 - The tolerance is unspecified and will remain at whatever the default is
#  * -1 - The tolerance is "erased".  If there was a default, the joint will be
#         allowed to move without restriction.

string name
float64 position  # in radians or meters (for a revolute or prismatic joint, respectively)
float64 velocity  # in rad/sec or m/sec
float64 acceleration  # in rad/sec^2 or m/sec^2
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class JointTolerance : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointTolerance";

        public String name;
        public Float64 position;
        public Float64 velocity;
        public Float64 acceleration;

        // Create an unpopulated message
        public JointTolerance()
        {
            name = new String();
            position = new Float64();
            velocity = new Float64();
            acceleration = new Float64();
        }
    }
}