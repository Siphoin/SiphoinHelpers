using UnityEditor.VersionControl;
using UnityEngine;
namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class InstantiatePrefabNode : BaseNodeInteraction
    {
        [SerializeField, Output(ShowBackingValue.Always)] private GameObject _prefab;

        [SerializeField, Input] private GameObject _parent;

        [SerializeField] private bool _dontDestroyOnLoad = false;

        public override void Execute()
        {
            Transform targetTransform = null;

            var valueParent = GetDataFromPort<GameObject>(nameof(_parent));

            if (valueParent != null)
            {
                targetTransform = valueParent.transform;
            }

            var prefab = Instantiate(_prefab, targetTransform);

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(prefab);
            }
        }
    }
}
