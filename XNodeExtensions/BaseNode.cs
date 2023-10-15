using SiphoinUnityHelpers.Attributes;
using System;
using UnityEngine;
using XNode;
#if UNITY_EDITOR
using XNodeEditor;
#endif

namespace SiphoinUnityHelpers.XNodeExtensions
{
    [NodeTint("#3b3b3b")]
    [NodeWidth(230)]
    public abstract class BaseNode : Node
    {
        [SerializeField, ReadOnly] private string _guid = Guid.NewGuid().ToString("N").Substring(0, 15);

        public string GUID => _guid;

        public virtual void Execute ()
        {
            throw new NotImplementedException($"Node {GetType().Name}");
        }

        protected T GetDataFromPort<T> (string fieldName)
        {
            return (T)GetDataFromPort(fieldName, typeof(T));

        }

        protected object GetDataFromPort(string fieldName, Type type)
        {
            var inputParentPort = GetInputPort(fieldName);

            if (inputParentPort.Connection is null)
            {
                return null;
            }

            var value = inputParentPort.Connection.GetOutputValue();

            if (value is null)
            {
                value = null;
            }

            return Convert.ChangeType(value, type);

        }
#if UNITY_EDITOR
        protected string GetDefaultName()
        {
            return NodeEditorUtilities.NodeDefaultName(GetType());
        }
#endif
    }
}
