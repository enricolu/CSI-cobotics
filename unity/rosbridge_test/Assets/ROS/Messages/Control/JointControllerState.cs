/*
Header header
float64 set_point
float64 process_value
float64 process_value_dot
float64 error
float64 time_step
float64 command
float64 p
float64 i
float64 d
float64 i_clamp
bool antiwindup
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class JointControllerState : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/JointControllerState";

        public Header header;
        public Float64 set_point;
        public Float64 process_value;
        public Float64 process_value_dot;
        public Float64 error;
        public Float64 time_step;
        public Float64 command;
        public Float64 p;
        public Float64 i;
        public Float64 d;
        public Float64 i_clamp;
        public Bool antiwindup;

        public JointControllerState()
        {
            set_point = new Float64();
            process_value = new Float64();
            process_value_dot = new Float64();
            error = new Float64();
            time_step = new Float64();
            command = new Float64();
            p = new Float64();
            i = new Float64();
            d = new Float64();
            i_clamp = new Float64();
            antiwindup = new Bool();
        }
    }
}