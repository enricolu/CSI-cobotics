/*
# The CollisionObject will be attached with a fixed joint to this link
string link_name

#This contains the actual shapes and poses for the CollisionObject
#to be attached to the link
#If action is remove and no object.id is set, all objects
#attached to the link indicated by link_name will be removed
CollisionObject object

# The set of links that the attached objects are allowed to touch
# by default - the link_name is already considered by default
string[] touch_links

# If certain links were placed in a particular posture for this object to remain attached 
# (e.g., an end effector closing around an object), the posture necessary for releasing
# the object is stored here
trajectory_msgs/JointTrajectory detach_posture

# The weight of the attached object, if known
float64 weight
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Trajectory;

namespace CSI.ROS.Messages.Moveit
{
    public class AttachedCollisionObject : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/AttachedCollisionObject";

        public String link_name;
        public CollisionObject obj;
        public String[] touch_links;
        public JointTrajectory detach_posture;
        public Float64 weight;

        public AttachedCollisionObject()
        {
            link_name = new String();
            obj = new CollisionObject();
            touch_links = new String[] { };
            detach_posture = new JointTrajectory();
            weight = new Float64();
        }
    }
}

