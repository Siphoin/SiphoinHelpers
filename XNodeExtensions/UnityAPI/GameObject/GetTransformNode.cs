using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.UnityAPI.GameObjects
{
    public class GetTransformNode : BaseNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private GameObject _gameObject;

        [Output(ShowBackingValue.Never), SerializeField] private Transform _output;

        public override object GetValue(NodePort port)
        {
            if (!Application.isPlaying)
            {
                return base.GetValue(port);
            }

            var gameObject = GetDataFromPort<GameObject>(nameof(_gameObject));

            return gameObject.transform;
        }
    }
}
