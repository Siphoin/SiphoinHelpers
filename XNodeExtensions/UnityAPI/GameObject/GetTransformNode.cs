using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.UnityAPI.GameObjects
{
    public class GetTransformNode : GetDataFromGameObjectNode<Transform>
    {
        protected override Transform GetData(GameObject gameObject)
        {
            return gameObject.transform;
        }
    }
}
