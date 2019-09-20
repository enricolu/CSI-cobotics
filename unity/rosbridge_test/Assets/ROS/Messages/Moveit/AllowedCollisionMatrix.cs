/*
    
# The list of entry names in the matrix
string[] entry_names

# The individual entries in the allowed collision matrix
# square, symmetric, with same order as entry_names
AllowedCollisionEntry[] entry_values

# In addition to the collision matrix itself, we also have 
# the default entry value for each entry name.

# If the allowed collision flag is queried for a pair of names (n1, n2)
# that is not found in the collision matrix itself, the value of
# the collision flag is considered to be that of the entry (n1 or n2)
# specified in the list below. If both n1 and n2 are found in the list 
# of defaults, the result is computed with an AND operation

string[] default_entry_names
bool[] default_entry_values
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class AllowedCollisionMatrix : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/AllowedCollisionMatrix";

        public String[] entry_names;
        public AllowedCollisionEntry[] entry_values;
        public String[] default_entry_names;
        public Bool[] default_entry_values;

        public AllowedCollisionMatrix()
        {
            entry_names = new String[] { };
            entry_values = new AllowedCollisionEntry[] { };
            default_entry_names = new String[] { };
            default_entry_values = new Bool[] { };
        }
    }
}

