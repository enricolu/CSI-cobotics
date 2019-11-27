/*
# The representation of a solution to a planning problem, including intermediate data

# The starting state considered for the robot solution path
RobotState trajectory_start

# The group used for planning (usually the same as in the request)
string group_name

# Multiple solution paths are reported, each reflecting intermediate steps in the trajectory processing

# The list of reported trajectories
RobotTrajectory[] trajectory

# Description of the reported trajectories (name of processing step)
string[] description

# The amount of time spent computing a particular step in motion plan computation 
float64[] processing_time

# Status at the end of this plan
MoveItErrorCodes error_code
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class MotionPlanDetailedResponse : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/MotionPlanDetailedResponse";

        public RobotState trajectory_start;
        public String group_name;
        public RobotTrajectory[] trajectory;
        public String[] description;
        public Float64[] processing_time;
        public MoveItErrorCodes error_code;

        public MotionPlanDetailedResponse()
        {
            trajectory_start = new RobotState();
            group_name = new String();
            trajectory = new RobotTrajectory[] { };
            description = new String[] { };
            processing_time = new Float64[] { };
            error_code = new MoveItErrorCodes();
        }
    }
}

