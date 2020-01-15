/*
# The representation of a solution to a planning problem

# The corresponding robot state
RobotState trajectory_start

# The group used for planning (usually the same as in the request)
string group_name

# A solution trajectory, if found
RobotTrajectory trajectory

# Planning time (seconds)
float64 planning_time

# Error code - encodes the overall reason for failure
MoveItErrorCodes error_code
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class MotionPlanResponse : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/MotionPlanResponse";

        public RobotState trajectory_start;
        public String group_name;
        public RobotTrajectory trajectory;
        public Float64 planning_time;
        public MoveItErrorCodes error_code;

        public MotionPlanResponse()
        {
            trajectory_start = new RobotState();
            group_name = new String();
            trajectory = new RobotTrajectory();
            planning_time = new Float64();
            error_code = new MoveItErrorCodes();
        }
    }
}

