using System;
using UnityEngine;

namespace BAUnity
{
    public static class Trace
    {
        #region Properties

        public static int FontSize = 12;

        private const string COLOR_INFO = "#56d6bf";
        private const string COLOR_WARN = "#ebbe0e";
        private const string COLOR_ERROR = "#eb420e";
        #endregion

        // Log
        public static void Log(object message)
        {
            Debug.Log(ApplyStyles(message));
        }

        public static void Log(object message, object obj)
        {
            Debug.Log(ApplyStyles(message, obj));
        }

        // Info
        public static void Info(object message)
        {
            Debug.Log(ApplyStyles(message, COLOR_INFO));
        }

        public static void Info(object message, object obj)
        {
            Debug.Log(ApplyStyles(message, COLOR_INFO, obj));
        }

        // Warn
        public static void Warn(object message)
        {
            Debug.LogWarning(ApplyStyles(message, COLOR_WARN));
        }

        public static void Warn(object message, object obj)
        {
            Debug.LogWarning(ApplyStyles(message, COLOR_WARN, obj));
        }

        // Error
        public static void Error(object message)
        {
            Debug.LogError(ApplyStyles(message, COLOR_ERROR));
        }

        public static void Error(object message, object obj)
        {
            Debug.LogError(ApplyStyles(message, COLOR_ERROR, obj));
        }

        // Exception
        public static void Exception(Exception ex)
        {
            Debug.LogException(ex);
        }

        public static void Exception(Exception ex, UnityEngine.Object obj)
        {
            Debug.LogException(ex, obj);
        }

        #region Apply Styles
        private static object ApplyStyles(object message)
        {
            object log =
                "<size=" + FontSize.ToString() + ">"
                + message
                + "</size>\n";

            return log;
        }

        private static object ApplyStyles(object message, object obj)
        {
            object log =
                "<size=" + FontSize.ToString() + ">"
                + "<b>[" + obj.GetType().FullName + "]</b>: "
                + message
                + "</size>\n";

            return log;
        }

        private static object ApplyStyles(object message, string color)
        {
            object log =
                "<size=" + FontSize.ToString() + ">"
                + "<color=" + color + ">"
                + message
                + "</color>"
                + "</size>\n";

            return log;
        }

        private static object ApplyStyles( object message, string color, object obj)
        {
            object log =
                "<size=" + FontSize.ToString() + ">"
                + "<color=" + color + ">"
                + "<b>[" + obj.GetType().FullName + "]</b>: "
                + message
                + "</color>"
                + "</size>\n";

            return log;
        }
        #endregion


    }
}
