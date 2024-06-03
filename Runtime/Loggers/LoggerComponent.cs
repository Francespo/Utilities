using System.Collections;
using UnityEngine;

namespace Francespo.Loggers
{
    public class LoggerComponent : MonoBehaviour
    {
        [SerializeField] bool showLogs;
        [SerializeField] bool showWarningLogs;
        [SerializeField] bool showErrorLogs;

        public LoggerComponent(bool showLogs, bool showWarningLogs, bool showErrorLogs)
        {
            this.showLogs = showLogs;
            this.showWarningLogs = showWarningLogs;
            this.showErrorLogs = showErrorLogs;
        }
        public LoggerComponent()
        {
            this.showLogs = true;
            this.showWarningLogs = true;
            this.showErrorLogs = true;
        }

        public void Log(object message, Object context)
        {
            if (showLogs) Debug.Log(message, context);
        }
        public void Log(object message)
        {
            if (showLogs) Debug.Log(message);
        }

        public void LogWarning(object message, Object context)
        {
            if (showWarningLogs) Debug.LogWarning(message, context);
        }
        public void LogWarning(object message)
        {
            if (showWarningLogs) Debug.LogWarning(message);
        }

        public void LogError(object message, Object context)
        {
            if (showErrorLogs) Debug.LogError(message, context);
        }
        public void LogError(object message)
        {
            if (showErrorLogs) Debug.LogError(message);
        }

        public void DrawLine(Vector3 start, Vector3 end)
        {
            if (showLogs) Debug.DrawLine(start, end);
        }
        public void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            if (showLogs) Debug.DrawLine(start, end, color);
        }
        public void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
        {
            if (showLogs) Debug.DrawLine(start, end, color, duration);
        }

        public void LogMultiple(IEnumerable objects)
        {
            if (showLogs)
            {
                string debug = string.Empty;
                foreach (object obj in objects)
                    debug += "\n" + obj;
                Debug.Log(debug);
            }

        }
        public void LogMultiple(string header, IEnumerable objects)
        {
            if (showLogs)
            {
                string debug = header;
                foreach (object obj in objects)
                    debug += "\n" + obj;
                Debug.Log(debug);
            }

        }
    }
}