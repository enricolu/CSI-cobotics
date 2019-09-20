/*
# Each multi-dof joint can specify a transform (up to 6 DOF)
geometry_msgs/Transform[] transforms

# There can be a velocity specified for the origin of the joint 
geometry_msgs/Twist[] velocities

# There can be an acceleration specified for the origin of the joint 
geometry_msgs/Twist[] accelerations

duration time_from_start
*/


using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;
using CSI.ROS.Messages.Geometry;

namespace CSI.ROS.Messages.Trajectory
{
    public class MultiDOFJointTrajectoryPoint : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "trajectory_msgs/MultiDOFJointTrajectoryPoint";

        public Transform[] transforms;
        public Twist[] velocities;
        public Twist[] accelerations;
        public Duration time_from_start;

        // Create an unpopulated message
        public MultiDOFJointTrajectoryPoint()
        {
            transforms = new Transform[] { };
            velocities = new Twist[] { };
            accelerations = new Twist[] { };
            time_from_start = new Duration();
        }
    }
}
