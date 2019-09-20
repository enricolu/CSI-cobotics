/*
# Constrain the position of a joint to be within a certain bound
string joint_name

# the bound to be achieved is [position - tolerance_below, position + tolerance_above]
float64 position
float64 tolerance_above
float64 tolerance_below

# A weighting factor for this constraint (denotes relative importance to other constraints. Closer to zero means less important)
float64 weight
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class JointConstraint : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/JointConstraint";

        public String joint_name;
        public Float64 position;
        public Float64 tolerance_above;
        public Float64 tolerance_below;
        public Float64 weight;

        public JointConstraint()
        {
            joint_name = new String();
            position = new Float64();
            tolerance_above = new Float64();
            tolerance_below = new Float64();
            weight = new Float64();
        }
    }
}

