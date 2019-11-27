/*
# Representation of a plane, using the plane equation ax + by + cz + d = 0

# a := coef[0]
# b := coef[1]
# c := coef[2]
# d := coef[3]

float64[4] coef
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Shape
{
    public class Plane : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "shape_msgs/Plane";

        public Float64[] coef;

        public Plane()
        {
            coef = new Float64[4];
        }
    }
}

