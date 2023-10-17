using SiphoinUnityHelpers.XNodeExtensions.Attributes;
using UnityEngine;
namespace SiphoinUnityHelpers.XNodeExtensions
{
    [NodeTint("#3b3b3b")]
    public class DebugNode : BaseNodeInteraction
    {
        [Space]

        [SerializeField, Input(ShowBackingValue.Never, ConnectionType.Override)] private Object _targetLog;

        [SerializeField, DebugNodeField, Input(connectionType = ConnectionType.Override)] private string _message;

        [Space]

        [SerializeField] private LogType _logType;

        public override void Execute()
        {
            object value = GetObjectForLog();

            switch (_logType)
            {
                case LogType.Message:
                    Debug.Log(value);
                    break;
                case LogType.Error:
                    Debug.LogError(value);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(value);
                    break;
                default:
                    break;
            }
        }

        private object GetObjectForLog ()
        {
            object inputMessage = GetInputValue<string>(nameof(_message));

            var objectTarget = GetInputValue<object>(nameof(_targetLog));

            if (objectTarget != null)
            {
                return objectTarget;
            }

            if (inputMessage != null)
            {
                return inputMessage;
            }

            return null;


        }
    }
}
