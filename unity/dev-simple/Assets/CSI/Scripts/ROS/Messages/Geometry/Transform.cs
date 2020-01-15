/*
# This represents the transform between two coordinate frames in free space.

Vector3 translation
Quaternion rotation
*/

using Newtonsoft.Json;

namespace CSI.ROS.Messages.Geometry
{
    public class Transform : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Transform";

        public Vector3 translation;
        public Quaternion rotation;

        // Create an unpopulated message
        public Transform()
        {
            translation = new Vector3 { };
            rotation = new Quaternion { };
        }
    }
}