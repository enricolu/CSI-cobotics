/*
# This message contains result from constraint evaluation
# result specifies the result of constraint evaluation 
# (true indicates state satisfies constraint, false indicates state violates constraint)
# if false, distance specifies a measure of the distance of the state from the constraint
# if true, distance is set to zero
bool result
float64 distance
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class ConstraintEvalResult : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/ConstraintEvalResult";

        public Bool result;
        public Float64 distance;

        public ConstraintEvalResult()
        {
            result = new Bool();
            distance = new Float64();
        }
    }
}

