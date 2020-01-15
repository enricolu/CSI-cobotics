/*
# the pose of the box
geometry_msgs/Pose pose

# the extents of the box, assuming the center is at the origin
geometry_msgs/Point32 extents
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class OrientedBoundingBox : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/OrientedBoundingBox";

        public Pose pose;
        public Point32 extents;

        public OrientedBoundingBox()
        {
            pose = new Pose();
            extents = new Point32();
        }
    }
}

