﻿/*
# This contains the position of a point in free space
float64 x
float64 y
float64 z
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Geometry
{
    public class Point : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Point";

        public Float64 x;
        public Float64 y;
        public Float64 z;

        // Create an unpopulated message
        public Point()
        {
            x = new Float64();
            y = new Float64();
            z = new Float64();
        }
    }
}
