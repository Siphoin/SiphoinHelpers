using SiphoinUnityHelpers.Attributes;
using System;
using UnityEditor.VersionControl;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public abstract class BaseNode : Node
    {
        [SerializeField, ReadOnly] private string _guid = Guid.NewGuid().ToString();

        public string GUID => _guid;

        public virtual void Execute ()
        {
            throw new NotImplementedException($"Node {GetType().Name}");
        }

        protected T GetDataFromPort<T> (string fieldName)
        {
            var inputParentPort = GetInputPort(fieldName);

            if (inputParentPort.Connection is null)
            {
                return default(T);
            }

            var value = inputParentPort.Connection.GetOutputValue();

            if (value is null)
            {
                value = default(T);
            }

            return (T)value;

        }
    }
}
