/*
uint8 PENDING         = 0   # The goal has yet to be processed by the action server
uint8 ACTIVE          = 1   # The goal is currently being processed by the action server
uint8 PREEMPTED       = 2   # The goal received a cancel request after it started executing
                            #   and has since completed its execution (Terminal State)
uint8 SUCCEEDED       = 3   # The goal was achieved successfully by the action server (Terminal State)
uint8 ABORTED         = 4   # The goal was aborted during execution by the action server due
                            #    to some failure (Terminal State)
uint8 REJECTED        = 5   # The goal was rejected by the action server without being processed,
                            #    because the goal was unattainable or invalid (Terminal State)
uint8 PREEMPTING      = 6   # The goal received a cancel request after it started executing
                            #    and has not yet completed execution
uint8 RECALLING       = 7   # The goal received a cancel request before it started executing,
                            #    but the action server has not yet confirmed that the goal is canceled
uint8 RECALLED        = 8   # The goal received a cancel request before it started executing
                            #    and was successfully cancelled (Terminal State)
uint8 LOST            = 9   # An action client can determine that a goal is LOST. This should not be
                            #    sent over the wire by an action server
GoalID goal_id
uint8 status
#Allow for the user to associate a string with GoalStatus for debugging
string text

*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.ActionLib
{
    public class GoalStatus : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "actionlib/GoalStatus";
        /*
        public uint PENDING = 0;
        public uint ACTIVE = 1;
        public uint PREEMPTED = 2;
        public uint SUCCEEDED = 3;
        public uint ABORTED = 4;
        public uint REJECTED = 5;
        public uint PREEMPTING = 6;
        public uint RECALLING = 7;
        public uint RECALLED = 8;
        public uint LOST = 9;

        public GoalID goal_id;
        public uint status;
        public string text;

        // Create an unpopulated message
        public GoalStatus()
        {
            goal_id = new GoalID();
            status = new uint();
            text = "";
        }
        */

        public Uint8 PENDING;
        public Uint8 ACTIVE;
        public Uint8 PREEMPTED;
        public Uint8 SUCCEEDED;
        public Uint8 ABORTED;
        public Uint8 REJECTED;
        public Uint8 PREEMPTING;
        public Uint8 RECALLING;
        public Uint8 RECALLED;
        public Uint8 LOST;

        public GoalID goal_id;
        public Uint8 status;
        public String text;

        // Create an unpopulated message
        public GoalStatus()
        {
            PENDING = new Uint8();
            PENDING.data = 0;

            PREEMPTED = new Uint8();
            PREEMPTED.data = 1;

            SUCCEEDED = new Uint8();
            SUCCEEDED.data = 3;

            ABORTED = new Uint8();
            ABORTED.data = 4;

            REJECTED = new Uint8();
            REJECTED.data = 5;

            PREEMPTED = new Uint8();
            PREEMPTING.data = 6;

            RECALLING = new Uint8();
            RECALLING.data = 7;

            RECALLED = new Uint8();
            RECALLED.data = 8;

            LOST = new Uint8();
            LOST.data = 9;

            goal_id = new GoalID();
            status = new Uint8();
            text = new String();
        }
    }
}
