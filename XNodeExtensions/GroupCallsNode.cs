using SiphoinUnityHelpers.Attributes;
using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    [NodeTint("#4b3359")]
    public class GroupCallsNode : NodeControlExecute
    {
        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private string _name;
        public override void Execute()
        {
                foreach (var item in GetExitPort().GetConnections())
                {
                    ExecuteNodesFromPort(item);
                }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            name = $"{_name} ({GetDefaultName()})";
        }
#endif
    }
}
