using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.GameObjects
{
    public class DontDestroyOnLoadNode : BaseNodeInteraction
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private GameObject _gameObject;

        public override void Execute()
        {
            var gameObject = GetDataFromPort<GameObject>(nameof(_gameObject));

            DontDestroyOnLoad(gameObject);
        }
    }
}
