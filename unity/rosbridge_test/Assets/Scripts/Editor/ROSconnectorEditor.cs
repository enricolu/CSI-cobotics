using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace CSI
{
    [Serializable]
    [CustomEditor(typeof(RobotBehaviour))]
    public class ROSconnectorEditor : Editor
    {
        // Constants
        private RobotBehaviour scriptInstance;
        private static GUIStyle buttonStyle;

        public override void OnInspectorGUI()
        {
            // Declare button style
            if (buttonStyle == null)
                buttonStyle = new GUIStyle(EditorStyles.miniButtonRight) { fixedWidth = 75 };

            // Define script instance
            RobotBehaviour scriptReference = (RobotBehaviour)target;

            // Get the ROS connection settings
            GUILayout.Space(5);
            ROSConnectionSettings(scriptReference);
            // Get the ROS messaging settings
            GUILayout.Space(5);
            ROSMessagingSettings(scriptReference);

            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }

        /// <summary>
        /// ///////// DRAW ROS CONNECTION SETTINGS ////////////
        /// </summary>
        void ROSConnectionSettings(RobotBehaviour scriptReference)
        {
            // Server Connection parameters
            GUILayout.Label("ROS Connection Properties", EditorStyles.boldLabel);

            // Joint state messages
            EditorGUILayout.BeginHorizontal();
            serializedObject.FindProperty("ROSAddress").stringValue =
                EditorGUILayout.TextField("Server Address:", scriptReference.ROSAddress.ToString());
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            serializedObject.FindProperty("ROSPort").stringValue =
                EditorGUILayout.TextField("Server Port:", scriptReference.ROSPort.ToString());
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(5);
            // Draw connect/disconnect button
            DisplaySettingsToggle(new GUIContent("Connection:",
                "Adds/removes ROS bridge for this robot."), scriptReference);
        }

        /// <summary>
        /// ///////// DRAW ROS MESSAGING SETTINGS ////////////
        /// </summary>
        void ROSMessagingSettings(RobotBehaviour scriptReference)
        {
            GUILayout.Label("Associated ROS Topics", EditorStyles.boldLabel);
            GUILayout.Label("Joint State Topics");
            // Joint state messages
            serializedObject.FindProperty("PublisherTopic_JointState").stringValue =
                EditorGUILayout.TextField("Publisher:", scriptReference.PublisherTopic_JointState.ToString());
            serializedObject.FindProperty("SubscriberTopic_JointState").stringValue =
                EditorGUILayout.TextField("Subscriber:", scriptReference.SubscriberTopic_JointState.ToString());
            //GUILayout.Space(5);
            GUILayout.Label("Goal State Topics");
            // Goal state messages
            serializedObject.FindProperty("PublisherTopic_GoalState").stringValue =
                EditorGUILayout.TextField("Publisher:", scriptReference.PublisherTopic_GoalState.ToString());
            serializedObject.FindProperty("SubscriberTopic_GoalState").stringValue =
                EditorGUILayout.TextField("Subscriber:", scriptReference.SubscriberTopic_GoalState.ToString());
        }

        // In-line button creator
        private static void DisplaySettingsToggle(GUIContent label, RobotBehaviour editInstance)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(label);
            if (GUILayout.Button("Create", buttonStyle))
                editInstance.DefineROSConnection();
            if (GUILayout.Button("Remove", buttonStyle))
                editInstance.RemoveROSConnection();
            EditorGUILayout.EndHorizontal();
        }
    }
}