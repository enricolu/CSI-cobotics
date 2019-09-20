/*
# The header is used to specify the coordinate frame and the reference time for the trajectory durations
std_msgs/Header header

# A representation of a multi-dof joint trajectory (each point is a transformation)
# Each point along the trajectory will include an array of positions/velocities/accelerations
# that has the same length as the array of joint names, and has the same order of joints as 
# the joint names array.

string[] joint_names
MultiDOFJointTrajectoryPoint[] points
*/

using Newtonsoft.Json;
using CSI.ROS.Messages;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Trajectory
{
    public class MultiDOFJointTrajectory : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "trajectory_msgs/MultiDOFJointTrajectory";

        public Header header;
        public String[] joint_names;
        public MultiDOFJointTrajectoryPoint[] points;

        // Create an unpopulated message
        public MultiDOFJointTrajectory()
        {
            header = new Header();
            joint_names = new String[] { };
            points = new MultiDOFJointTrajectoryPoint[] { };
        }
    }
}

