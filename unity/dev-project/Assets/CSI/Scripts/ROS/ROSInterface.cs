using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RS = RosSharp.RosBridgeClient;

namespace CSI.ROS
{
    public class ROSInterface : MonoBehaviour
    {
        /*
         * This connector object is designed to be a wrapper for the RosSharp library. 
         * It provides quick access for generic robot configurations.
         */

        // Get connection parameters from inputs
        public string address { get; set; }
        public string port { get; set; } 
        public int timeOut { get; set; }

        /*
         * Component behaviours
         */

        void OnAwake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
        
        }
        // Update is called once per frame
        void Update()
        {

        }
        // On component destruction
        void OnDestroy()
        {
            Disconnect();  // On destruction of the ROSconnector, remove the RosSharp connector
        }

        /*
         * Create connection object
         */
        // Create a connection to a ROS network
        public void Connect()
        {
            // Create a ROS connector
            RS.RosConnector rosConnector = this.gameObject.AddComponent<RS.RosConnector>();
            rosConnector.RosBridgeServerUrl = "ws://" + address.ToString() + ":" + port.ToString();
            rosConnector.Timeout = timeOut;
        }
        // Remove the ROSbridge
        public void Disconnect()
        {
            //Debug.Log("[" + this.name+"] Destroying connection to" + this.gameObject.name + "@" + address + ":" + port);
            // Destroy the component
            this.enabled = false;
        }

        /*
         * Create different data transfer patches
         */
        // Create image publisher
        public void CreateImagePublisher(Camera targetCamera, string topic, int resolutionWidth, int resolutionHeight)
        {
            // Create the image publisher component
            RS.ImagePublisher publisher = this.gameObject.AddComponent<RS.ImagePublisher>();
            // Parameterise the publisher
            publisher.ImageCamera = targetCamera;
            publisher.resolutionWidth = resolutionWidth;
            publisher.resolutionHeight = resolutionHeight;
            publisher.FrameId = this.name;
            publisher.Topic = topic;

        }
        // Create image subscribe
        public void CreateImageSubscriber(Camera targetCamera, string topic)
        {
            // Create the image subscriber component
            RS.ImageSubscriber subscriber = this.gameObject.AddComponent<RS.ImageSubscriber>();
            // Parameterise the subscriber
            subscriber.Topic = topic;
        }
    }
}
