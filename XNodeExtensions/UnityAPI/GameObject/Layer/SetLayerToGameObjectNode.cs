using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.UnityAPI.GameObjects.Layer
{
    public class SetLayerToGameObjectNode : SetDataToGameObjectNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private int _layer;
        public override void SetData(GameObject gameObject)
        {
            int layer = _layer;

            var inputLayer = GetInputPort(nameof(_layer));

            if (inputLayer.Connection != null)
            {
                layer = GetInputValue<int>(nameof(_layer));
            }

            gameObject.layer = layer;
        }
    }
}
