using UnityEngine;
namespace SiphoinUnityHelpers.XNodeExtensions
{
    [NodeTint("#3b3b3b")]
    public class DebugNode : BaseNodeInteraction
    {
        [Space]

        [SerializeField, Input(ShowBackingValue.Never, ConnectionType.Override)] private UnityEngine.Object _message;

        [Space]

        [SerializeField] private LogType _logType;

        public override void Execute()
        {
            var value = GetDataFromPort<object>(nameof(_message));

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
    }
}
