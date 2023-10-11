using AboveSnakes.Interfaces;
using RandomizableFields;
using System;
using UnityEngine;

namespace AboveSnakes.GameDesign
{
    public class ScriptableObjectIdentity : ScriptableObject, Iidentity
    {
        [SerializeField, RandomizableGuid] private string _guid = Guid.NewGuid().ToString();

        public string GUID => _guid;
    }
}