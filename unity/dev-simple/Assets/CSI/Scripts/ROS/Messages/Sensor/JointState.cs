/*
# This is a message that holds data to describe the state of a set of torque controlled joints. 
#
# The state of each joint (revolute or prismatic) is defined by:
#  * the position of the joint (rad or m),
#  * the velocity of the joint (rad/s or m/s) and 
#  * the effort that is applied in the joint (Nm or N).
#
# Each joint is uniquely identified by its name
# The header specifies the time at which the joint states were recorded. All the joint states
# in one message have to be recorded at the same time.
#
# This message consists of a multiple arrays, one for each part of the joint state. 
# The goal is to make each of the fields optional. When e.g. your joints have no
# effort associated with them, you can leave the effort array empty. 
#
# All arrays in this message should have the same size, or be empty.
# This is the only way to uniquely associate the joint name with the correct
# states.

Header header

string[] name
float64[] position
float64[] velocity
float64[] effort
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Sensor
{
    public class JointState : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "sensor_msgs/JointState";

        public Header header;
        public String[] name;
        public Float64[] position;
        public Float64[] velocity;
        public Float64[] effort;

        public JointState()
        {
            header = new Header();
            name = new String[] { };
            position = new Float64[] { };
            velocity = new Float64[] { };
            effort = new Float64[] { };
        }
    }
}

