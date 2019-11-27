using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotSuppliments
{

    public static class Logger 
    {
        // Push message to log
        public static void Log(object obj, UnityEngine.Object context = null)
        {
            Debug.Log(string.Concat(System.DateTime.UtcNow.ToString(
                "[yyyy-MM-dd HH:mm:ss.fff] "), obj), context);
        }
        // Push warning to log
        public static void LogWarning(object obj, UnityEngine.Object context = null)
        {
            Debug.LogWarning(string.Concat(System.DateTime.UtcNow.ToString(
                "[yyyy-MM-dd HH:mm:ss.fff] "), obj), context);
        }
        // Push error log
        public static void LogError(object obj, UnityEngine.Object context = null)
        {
            Debug.LogError(string.Concat(System.DateTime.UtcNow.ToString(
                "[yyyy-MM-dd HH:mm:ss.fff] "), obj), context);
        }
    }

}
