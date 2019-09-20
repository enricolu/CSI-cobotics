using UnityEngine;
using RosSharp;

namespace CSI.ROS.Messages
{
    // Passes a unity pose (position & orientation to a ROS pose message
    public class PoseStampedPublisher : Publisher<Geometry.PoseStamped>
    {
        public Transform PublishedTransform;
        public string FrameId = "Unity";

        // The message container
        private Geometry.PoseStamped message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            // Instantiate the geometry.PoseStamped message
            message = new Geometry.PoseStamped
            {
                header = new Standard.Header()
                {
                    frame_id = FrameId
                }
            };
        }

        private void UpdateMessage()
        {
            // Update the header (time data)
            message.header.Update();
            // Append the position components
            message.pose.position = GetGeometryPoint(PublishedTransform.position.Unity2Ros());
            // Append the orientation components
            message.pose.orientation = GetGeometryQuaternion(PublishedTransform.rotation.Unity2Ros());
            // Publish the message definitions
            Publish(message);
        }

        private Geometry.Point GetGeometryPoint(Vector3 position)
        {
            Geometry.Point geometryPoint = new Geometry.Point();
            geometryPoint.x = position.x;
            geometryPoint.y = position.y;
            geometryPoint.z = position.z;
            return geometryPoint;
        }

        private Geometry.Quaternion GetGeometryQuaternion(Quaternion quaternion)
        {
            Geometry.Quaternion geometryQuaternion = new Geometry.Quaternion();
            geometryQuaternion.x = quaternion.x;
            geometryQuaternion.y = quaternion.y;
            geometryQuaternion.z = quaternion.z;
            geometryQuaternion.w = quaternion.w;
            return geometryQuaternion;
        }
    }
}
