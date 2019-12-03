using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.Robot
{
    // Robot kinematic types
    public enum dynamics {serial, mobile, hybrid };

    public class Robot : Device
    {
        // General robot parameters
        [Header("Robot Parameters")]
        // Parameters
        [Tooltip("The robot kinematic types")]
        public dynamics config = dynamics.serial;
        // [Tooltip("")]


        private bool activeInterface = false;        

        // Start is called before the first frame update
        void OnAwake()
        {

        }

        // Update is called once per frame
        void Update()
        {
            /*
             * This handles the update of the 'robot' digital twins
             */
            switch (twinBehaviour)
            {
                case TwinMode.passive:

                    return;
                case TwinMode.emulated:

                    return;
                case TwinMode.networked:

                    return;
                default:
                    Debug.Log("Twin mode not recognised for '" + name);
                    return;
            }

            // Get the general connection interface
            NetworkInterface networkBridge = this.gameObject.GetComponent<NetworkInterface>();
            
            // Sanity check. has adapter and is not disabled 
            if (networkBridge == null || !networkBridge.isActiveAndEnabled)
                return;
            // Check enabled controller
            if (!networkBridge.isEnabled)
                return;

            // Create or destroy network bridge depending on selection
            if (!activeInterface && networkBridge.IsConnected())
            {
                CreateIOComponents();
                activeInterface = true;
            }
            else if (activeInterface && !networkBridge.IsConnected())
            {
                //DestroyInterface(type);
                activeInterface = false;
            }
        }

        /*
         * Create the Robot patch interfaces
         */
        private void CreateIOComponents()
        {
            switch (config)
            {
                case (dynamics.serial):
                    // Create the joint state mirror
                    //this.gameObject.AddComponent<ROSConnector>();
                    break;
                default:
                    Debug.Log("Type " + config.ToString() + " not implemented yet.");
                    return;
            }
        }
    }
}


