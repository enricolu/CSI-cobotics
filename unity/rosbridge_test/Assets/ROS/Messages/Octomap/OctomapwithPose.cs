/*
# A 3D map in binary format, as Octree
Header header

# The pose of the octree with respect to the header frame 
geometry_msgs/Pose origin

# The actual octree msg
octomap_msgs/Octomap octomap
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Octomap
{
    public class OctomapWithPose : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "octomap_msgs/OctomapwithPose";

        public Header header;
        public Pose origin;
        public Octomap octomap;

        public OctomapWithPose()
        {
            header = new Header();
            origin = new Pose();
            octomap = new Octomap();
        }
    }
}
