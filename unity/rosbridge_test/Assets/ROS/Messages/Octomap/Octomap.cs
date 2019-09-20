/*
# A 3D map in binary format, as Octree
Header header

# Flag to denote a binary (only free/occupied) or full occupancy octree (.bt/.ot file)
bool binary

# Class id of the contained octree 
string id

# Resolution (in m) of the smallest octree nodes
float64 resolution

# binary serialization of octree, use conversions.h to read and write octrees
int8[] data
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Octomap
{
    public class Octomap : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "octomap_msgs/Octomap";

        public Header header;
        public Bool binary;
        public String id;
        public Float64 resolution;
        public Int8[] data;

        public Octomap()
        {
            header = new Header();
            binary = new Bool();
            id = new String();
            resolution = new Float64();
            data = new Int8[] { };
        }
    }
}
