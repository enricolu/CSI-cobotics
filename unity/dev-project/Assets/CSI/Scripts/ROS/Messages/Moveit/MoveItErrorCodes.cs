/*
int32 val

# overall behavior
int32 SUCCESS=1
int32 FAILURE=99999

int32 PLANNING_FAILED=-1
int32 INVALID_MOTION_PLAN=-2
int32 MOTION_PLAN_INVALIDATED_BY_ENVIRONMENT_CHANGE=-3
int32 CONTROL_FAILED=-4
int32 UNABLE_TO_AQUIRE_SENSOR_DATA=-5
int32 TIMED_OUT=-6
int32 PREEMPTED=-7

# planning & kinematics request errors
int32 START_STATE_IN_COLLISION=-10
int32 START_STATE_VIOLATES_PATH_CONSTRAINTS=-11

int32 GOAL_IN_COLLISION=-12
int32 GOAL_VIOLATES_PATH_CONSTRAINTS=-13
int32 GOAL_CONSTRAINTS_VIOLATED=-14

int32 INVALID_GROUP_NAME=-15
int32 INVALID_GOAL_CONSTRAINTS=-16
int32 INVALID_ROBOT_STATE=-17
int32 INVALID_LINK_NAME=-18
int32 INVALID_OBJECT_NAME=-19

# system errors
int32 FRAME_TRANSFORM_FAILURE=-21
int32 COLLISION_CHECKING_UNAVAILABLE=-22
int32 ROBOT_STATE_STALE=-23
int32 SENSOR_INFO_STALE=-24

# kinematics errors
int32 NO_IK_SOLUTION=-31
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Moveit
{
    public class MoveItErrorCodes : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "moveit_msgs/MoveItErrorCodes";

        public Int32 val;

        public int SUCCESS = 1;
        public int FAILURE = 99999;

        public int PLANNING_FAILED = -1;
        public int INVALID_MOTION_PLAN = -2;
        public int MOTION_PLAN_INVALIDATED_BY_ENVIRONMENT_CHANGE = -3;
        public int CONTROL_FAILED = -4;
        public int UNABLE_TO_AQUIRE_SENSOR_DATA = -5;
        public int TIMED_OUT = -6;
        public int PREEMPTED = -7;

        public int START_STATE_IN_COLLISION = -10;
        public int START_STATE_VIOLATES_PATH_CONSTRAINTS = -11;

        public int GOAL_IN_COLLISION = -12;
        public int GOAL_VIOLATES_PATH_CONSTRAINTS = -13;
        public int GOAL_CONSTRAINTS_VIOLATED = -14;

        public int INVALID_GROUP_NAME = -15;
        public int INVALID_GOAL_CONSTRAINTS = -16;
        public int INVALID_ROBOT_STATE = -17;
        public int INVALID_LINK_NAME = -18;
        public int INVALID_OBJECT_NAME = -19;

        public int FRAME_TRANSFORM_FAILURE = -21;
        public int COLLISION_CHECKING_UNAVAILABLE = -22;
        public int ROBOT_STATE_STALE = -23;
        public int SENSOR_INFO_STALE = -24;

        public int NO_IK_SOLUTION = -31;

        public MoveItErrorCodes()
        {
            val = new Int32();
        }
    }
}

