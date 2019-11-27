/*   
# defines a translation for the gripper, used in pickup or place tasks
# for example for lifting an object off a table or approaching the table for placing

# the direction of the translation
geometry_msgs/Vector3Stamped direction

# the desired translation distance
float32 desired_distance

# the min distance that must be considered feasible before the
# grasp is even attempted
float32 min_distance
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Geometry;
using CSI.ROS.Messages.Standard;


namespace CSI.ROS.Messages.Moveit
{
    public class GripperTranslation : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/GripperTranslation";

        public Vector3Stamped direction;
        public Float32 desired_distance;
        public Float32 min_distance;

        public GripperTranslation()
        {
            direction = new Vector3Stamped();
            desired_distance = new Float32();
            min_distance = new Float32();
        }
    }
}

