
namespace CSI.ROS.Messages
{
    // Simply brings the generic Publisher into the CSI.ROS.Message namespace
    public abstract class Publisher<T> : RosSharp.RosBridgeClient.Publisher<T> where T : Message
    {

    }
    // Simply bring the generic subscriber int othe CSI.ROS.Message namespace
    public abstract class Subscriber<T> : RosSharp.RosBridgeClient.Subscriber<T> where T : Message
    {

    }

    public static class HeaderExtensions
    {
        // Define the update for the standard header in the CSI context
        public static void Update(this Standard.Header header)
        {
            float time = UnityEngine.Time.realtimeSinceStartup;
            uint secs = (uint)time;
            uint nsecs = (uint)(1e9 * (time - secs));
            header.seq++;
            header.stamp.secs = secs;
            header.stamp.nsecs = nsecs;
        }
    }
}
