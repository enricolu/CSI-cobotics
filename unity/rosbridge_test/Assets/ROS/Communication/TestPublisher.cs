/*
namespace RosSharp.RosBridgeClient
{
    public class FloatPublisher : Publisher<Messages.Standard.Float32>
    {
        public float messageData;

        private Messages.Standard.Float32 message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new Messages.Standard.Float32
            {
                data = messageData
            };
        }

        private void Update()
        {
            message.data = messageData;
            Publish(message);
        }
    }
}
*/

namespace CSI.ROS.Messages
{
    public class TestPublisher : Publisher<Geometry.Point32>
    {
        public float x;
        public float y;
        public float z;

        private Geometry.Point32 message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new Geometry.Point32();

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
