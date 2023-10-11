using AboveSnakes.Attributes;
using RandomizableFields;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace AboveSnakes
{
    public class MonoBehaviourIdentity : MonoBehaviour
    {
         [SerializeField, ReadOnly(ReadOnlyMode.OnPlayMode)] private string _guid;

        public string GUID => _guid;

        public void SetGuid()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public void SetGuid(string guid)
        {
            if (!Guid.TryParse(guid, out Guid _))
            {
                return;
            }

            _guid = guid;
        }

#if UNITY_EDITOR

        private void OnValidate()
        {

            ValidateGUID();
        }

        public void ValidateGUID()
        {

#pragma warning disable CS0618 // Тип или член устарел
            PrefabType prefabType = PrefabUtility.GetPrefabType(gameObject);
#pragma warning restore CS0618 // Тип или член устарел

            if (Application.isPlaying)
            {
                return;
            }

            if (prefabType == PrefabType.PrefabInstance && string.IsNullOrEmpty(_guid))
            {
                SetGuid();
            }

            else if (prefabType != PrefabType.PrefabInstance)
            {
                _guid = string.Empty;
            }
        }

#endif
    }
}