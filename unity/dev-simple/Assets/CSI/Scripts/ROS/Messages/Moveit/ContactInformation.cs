/*
# Standard ROS header contains information 
# about the frame in which this 
# contact is specified
Header header

# Position of the contact point
geometry_msgs/Point position

# Normal corresponding to the contact point
geometry_msgs/Vector3 normal 

# Depth of contact point
float64 depth

# Name of the first body that is in contact
# This could be a link or a namespace that represents a body
string contact_body_1
uint32 body_type_1

# Name of the second body that is in contact
# This could be a link or a namespace that represents a body
string contact_body_2
uint32 body_type_2

uint32 ROBOT_LINK=0
uint32 WORLD_OBJECT=1
uint32 ROBOT_ATTACHED=2
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Moveit
{
    public class ContactInformation : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/ContactInformation";

        public Vector3 normal;
        public Float64 depth;
        public String contact_body_1;
        public Uint32 body_type_1;
        public String contact_body_2;
        public Uint32 body_type_2;
        public Uint32 ROBOT_LINK;
        public Uint32 WORLD_OBJECT;
        public Uint32 ROBOT_ATTACHED;

        public ContactInformation()
        {
            normal = new Vector3();
            depth = new Float64();
            contact_body_1 = new String();
            body_type_1 = new Uint32();
            contact_body_2 = new String();
            body_type_2 = new Uint32();
            ROBOT_LINK = new Uint32();
            ROBOT_LINK.data = 0;
            WORLD_OBJECT = new Uint32();
            WORLD_OBJECT.data = 1;
            ROBOT_ATTACHED = new Uint32();
            ROBOT_ATTACHED.data = 2;
        }
    }
}

