/*
# This message contains a list of motion planning constraints.
# All constraints must be satisfied for a goal to be considered valid

string name

JointConstraint[] joint_constraints

PositionConstraint[] position_constraints

OrientationConstraint[] orientation_constraints

VisibilityConstraint[] visibility_constraints
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class Constraints : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/Constraints";

        public String name;
        public JointConstraint[] joint_constraints;
        public OrientationConstraint[] orientation_constraints;
        public VisibilityConstraint[] visibility_constraints;

        public Constraints()
        {
            name = new String();
            joint_constraints = new JointConstraint[] { };
            orientation_constraints = new OrientationConstraint[] { };
            visibility_constraints = new VisibilityConstraint[] { };
        }
    }
}

