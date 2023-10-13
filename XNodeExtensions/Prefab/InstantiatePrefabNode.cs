﻿using UnityEditor.VersionControl;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Prefabs
{
    public class InstantiatePrefabNode : BaseNodeInteraction
    {
        [SerializeField, Input] private GameObject _prefab;

        [SerializeField, Input(ShowBackingValue.Never, ConnectionType.Override)] private GameObject _parent;

        private GameObject _result;

        public override void Execute()
        {
            Transform targetTransform = null;

            var valueParent = GetDataFromPort<GameObject>(nameof(_parent));

            var selectedPrefab = _prefab;

            var prefabFromConnection = GetDataFromPort<GameObject>(nameof(_prefab));

            if (prefabFromConnection != null)
            {
                selectedPrefab = prefabFromConnection;
            }

            if (valueParent != null)
            {
                targetTransform = valueParent.transform;
            }

            _result = Instantiate(selectedPrefab, targetTransform);
        }

        public override object GetValue(NodePort port)
        {
            return _result;
        }
    }
}
