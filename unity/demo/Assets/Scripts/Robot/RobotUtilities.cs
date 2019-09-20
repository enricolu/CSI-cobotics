using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.Urdf;

namespace CSI
{
    public class RobotUtilities : MonoBehaviour
    {
        private const string RobotTag = "Robot";
        private const float finiteZero = 0.00001f;
        /// <summary>
        /// GENERAL
        /// </summary>
        /// <returns></returns>
        /// 
        // Determine if a game object is a "Robot"
        public static bool IsRobot(GameObject entity)
        {
            return entity.CompareTag(RobotTag);
        }
        // A tolerance on zero
        public static float GetZero()
        {
            return finiteZero;
        }
        /// <summary>
        /// GET COMMUNICATION INTERFACES
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        ///
        // Get the robot's dedicated ROS-Bridge
        public static GameObject GetRobotROSBridge(GameObject robot)
        {
            // Find the robots ROSBridge
            GameObject rosBridgeObject = FindChildWithTag(robot.transform, "ROSBridge");
            // Check the robot has a dedicated ROS-bridge (and associated URL)
            if (rosBridgeObject == null)
            {
                Debug.LogError("Message cannot be sent, robot has no associated ROSbridge.");
                return null;
            }
            Debug.Log("ROS connection found at: " + rosBridgeObject.name);
            return rosBridgeObject;
        }

        /// <summary>
        /// OBJECT SORTING AND HIERARCHY TRANSVERSAL
        /// </summary>
        /// <returns></returns>
        /// 
        // Search through parent transform for gameobject with tag
        public static GameObject FindChildWithTag(Transform parent, string _tag)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.gameObject.CompareTag(_tag))
                {
                    // Return the first child with the associated tag
                    return child.gameObject;
                }
                /* % Recursion through children
                if (child.childCount > 0)
                {
                    GetChildObject(child, _tag);
                }
                */
            }
            return null;
        }
        // Search through parent transform for gameobject with tag
        public static GameObject ApplyTagToChildren(Transform parent, string _tag)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                child.tag = _tag;

                // Recursion through children
                if (child.childCount > 0)
                {
                    ApplyTagToChildren(child, _tag);
                }

            }
            return null;
        }
        // Search for the parent hierchy for the most senior tag instance
        public static GameObject FindMaximalParentByTag(Transform child, string _tag)
        {
            // Child doesn't have the tag or parent has no gameobject
            if (child.tag != _tag || child.parent == null)
                return child.gameObject;
            // Get the game object of the parent
            GameObject parentGO = child.parent.gameObject;
            if (parentGO.CompareTag(_tag))
            {
                GameObject gameobjectParent = FindMaximalParentByTag(parentGO.transform, _tag);
                return gameobjectParent;
            }
            // The parent doesn't have the tag, return the child's gameobject
            return child.gameObject;
        }
        // Find the "world" transform of the robot
        public static Transform  FindRobotWorldTransform(Transform member)
        {
            if (member.parent == null)
            {
                Debug.LogWarning("Unable to find 'World' transform.");
                return null;
            }

            // Check the parent
            if (member.name != "world")
            {
                return FindRobotWorldTransform(member.parent);
            }
            return member;
        }

        /// <summary>
        /// Get Information from the URDF
        /// </summary>
        /// <returns></returns>
        /// 
        // Get the maximal reach from the URDF
        public static float GetURDFMaximumReach(GameObject robot)
        {
            float componentRadius = 0;
            //Vector3 robotOrigin = robot.transform.position;

            // Extract the distance from the robot origin
            List<UrdfJoint> jointList = GetURDFJointList(robot);
            for (int i = 1; i < jointList.Count; i++)
            {
                //robotOrigin += jointList[i].transform.position;
                // Append the scalar reach distance
                componentRadius += jointList[i].transform.position.magnitude;
            }
            return componentRadius;
        }
        // Return the URDF joints
        public static List<UrdfJoint> GetURDFJointList(GameObject robot)
        {
            // Get the URDF description
            UrdfRobot robotURDF = robot.GetComponent<UrdfRobot>();
            if (robotURDF == null)
                return null;

            List<UrdfJoint> jointList = new List<UrdfJoint>();

            foreach (UrdfJoint urdfJoint in robotURDF.GetComponentsInChildren<UrdfJoint>())
            {
                jointList.Add(urdfJoint);
            }
            return jointList;
        }
        // Return simply the joint names
        public static List<string> GetJointList(GameObject robot)
        {
            // Get the URDF description
            UrdfRobot robotURDF = robot.GetComponent<UrdfRobot>();
            if (robotURDF == null)
                return null;

            List<string> jointList = new List<string>();
            foreach (UrdfJoint urdfJoint in robotURDF.GetComponentsInChildren<UrdfJoint>())
            {
                jointList.Add(urdfJoint.JointName);
            }
            return jointList;
        }
    }

    [RequireComponent(typeof(RobotDescription))]
    public class RobotVisuals : MonoBehaviour
    {
        // Constant properties
        private const string hologramTag = "Hologram";

        // Define Range Of Motion semi-transparent object
        public static GameObject GetSphericaHologram(GameObject robot)
        {
            //Calculate maximum reach of the robot
            float radius = RobotUtilities.GetURDFMaximumReach(robot);

            // Create the hologram 
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(1, 1, 1) * radius / 1.4f;
            sphere.transform.position = robot.transform.position;
            sphere.tag = hologramTag;

            // No collider
            Destroy(sphere.GetComponent<SphereCollider>());

            // Make the hologram a child of the robot parent
            sphere.transform.SetParent(robot.transform);

            // Return the resulting hologram
            return sphere;
        }
    }
}