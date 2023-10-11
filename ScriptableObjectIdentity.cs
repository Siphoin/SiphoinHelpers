using AboveSnakes.Interfaces;
using RandomizableFields;
using System;
using UnityEngine;

namespace SiphoinUnityHelpers
{
    public class ScriptableObjectIdentity : ScriptableObject, Iidentity
    {
        [SerializeField] private string _guid = Guid.NewGuid().ToString();

        public string GUID => _guid;
    }
}
