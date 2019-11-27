/*
# This represents force in free space, seperated into 
# it's linear and angular parts.  
Vector3  force
Vector3  torque
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Geometry
{
    public class Wrench : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Wrench";

        public Vector3 force;
        public Vector3 torque;

        public Wrench()
        {
            force = new Vector3();
            torque = new Vector3();
        }
    }
}
