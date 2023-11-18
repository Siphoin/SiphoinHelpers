using System;
using UnityEngine;

namespace SiphoinUnityHelpers
{
    public class ScriptableObjectIdentity : ScriptableObject
    {
        [SerializeField] private string _guidObject = Guid.NewGuid().ToString();

        public string GUID => _guidObject;
    }
}
