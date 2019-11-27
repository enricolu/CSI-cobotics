/*
# This message contains a set of parameters useful in
# setting up the volume (a box) in which the robot is allowed to move.
# This is useful only when planning for mobile parts of 
# the robot as well.

# Define the frame of reference for the box corners
Header header

# The minumum corner of the box, with respect to the robot starting pose
geometry_msgs/Vector3 min_corner

# The maximum corner of the box, with respect to the robot starting pose
geometry_msgs/Vector3 max_corner
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class WorkspaceParameters : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/WorkspaceParameters";

        public Header header;
        public Vector3 min_corner;
        public Vector3 max_corner;

        public WorkspaceParameters()
        {
            header = new Header();
            min_corner = new Vector3();
            max_corner = new Vector3();
        }
    }
}

