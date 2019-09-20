/*
Header header
duration timestep
float64 error
float64 error_dot
float64 p_error
float64 i_error
float64 d_error
float64 p_term
float64 i_term
float64 d_term
float64 i_max
float64 i_min
float64 output
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Control
{
    public class PidState : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "control_msgs/PidState";

        public Header header;
        public Duration timestep;
        public Float64 error;
        public Float64 error_dot;
        public Float64 p_error;
        public Float64 i_error;
        public Float64 d_error;
        public Float64 p_term;
        public Float64 i_term;
        public Float64 d_term;
        public Float64 i_max;
        public Float64 i_min;
        public Float64 output;

        // Create an unpopulated message
        public PidState()
        {
            header = new Header();
            timestep = new Duration();
            error = new Float64();
            error_dot = new Float64();
            p_error = new Float64();
            i_error = new Float64();
            d_error = new Float64();
            p_term = new Float64();
            i_term = new Float64();
            d_term = new Float64();
            i_max = new Float64();
            i_min = new Float64();
            output = new Float64();
        }
    }
}
