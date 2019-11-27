/*
# collision objects
CollisionObject[] collision_objects

# The octomap that represents additional collision data
octomap_msgs/OctomapWithPose octomap
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Octomap;

namespace CSI.ROS.Messages.Moveit
{
    public class PlanningSceneWorld : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/PlanningSceneWorld";

        public CollisionObject[] collision_objects;
        public OctomapWithPose octomap;

        public PlanningSceneWorld()
        {
            collision_objects = new CollisionObject[] { };
            octomap = new OctomapWithPose();
        }
    }
}