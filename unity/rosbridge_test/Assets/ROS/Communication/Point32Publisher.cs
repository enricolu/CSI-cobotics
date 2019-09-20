using RosSharp.RosBridgeClient;

namespace CSI.ROS
{
    public class Point32Publisher : Publisher<Messages.Geometry.Point32>
    {
        public float x;
        public float y;
        public float z;

        private Messages.Geometry.Point32 message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new Messages.Geometry.Point32();

            message.x = x;
            message.y = y;
            message.z = z;

        }

        private void Update()
        {
            message.x = x;
            message.y = y;
            message.z = z;

            Publish(message);
        }
    }
}
