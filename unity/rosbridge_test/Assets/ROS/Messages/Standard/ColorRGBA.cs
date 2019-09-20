/*
float32 r
float32 g
float32 b
float32 a
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Standard
{
    public class ColorRGBA : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/ColorRGBA";

        public Float32 r;
        public Float32 g;
        public Float32 b;
        public Float32 a;

        public ColorRGBA()
        {
            r = new Float32();
            g = new Float32();
            b = new Float32();
            a = new Float32();
        }
    }
}