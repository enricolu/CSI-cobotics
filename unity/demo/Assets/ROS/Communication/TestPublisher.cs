using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

namespace CSI.ROS
{
    public class TestPublisher : RosSharp.RosBridgeClient.Publisher<Messages.Geometry.Point32>
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

            message.x.data = x;
            message.y.data = y;
            message.z.data = z;

        }

        private void Update()
        {
            message.x.data = x;
            message.y.data = y;
            message.z.data = z;

            Publish(message);
        }
    }
}
