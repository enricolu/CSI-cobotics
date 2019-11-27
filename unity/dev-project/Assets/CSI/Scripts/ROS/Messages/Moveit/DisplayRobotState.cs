/*
# The robot state to display
RobotState state

# Optionally, various links can be highlighted
ObjectColor[] highlight_links
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Moveit
{
    public class DisplayRobotState : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/DisplayRobotState";

        public RobotState state;
        public ObjectColor[] highlight_links;

        public DisplayRobotState()
        {
            state = new RobotState();
            highlight_links = new ObjectColor[] { };
        }
    }
}

