using UnityEngine;
using System;
using XNode;
using SiphoinUnityHelpers.Attributes;
using SiphoinUnityHelpers.Extensions;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public abstract class VaritableNode : BaseNode
    {
        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private string _name;

        public string Name { get => _name; set => _name = value; }

        public virtual object GetStartValue ()
        {
            throw new NotImplementedException();
        }

    }

    public abstract class VaritableNode<T> : VaritableNode
    {
       private T _startValue;

        [SerializeField, Output(ShowBackingValue.Always), ReadOnly(ReadOnlyMode.OnEditor)] private T _value;

        [Space(40)]

        [SerializeField] private Color _color = Color.white;

        public override object GetStartValue()
        {
           return _startValue;
        }

        public override object GetValue(NodePort port)
        {
            return _value;
        }

        public void SetValue (T value)
        {
            _value = value;
        }

        private void OnValidate()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            if (!Application.isPlaying)
            {
                if (string.IsNullOrEmpty(Name))
                {
                    var nodesOnGraph = graph.nodes.Count(x => x.GetType() == GetType());

                    Name = $"{_value.GetType().Name} ({nodesOnGraph})";
                }
                _startValue = _value;

                name = _color.ToColorTag($"{Name} ({_value.GetType().Name})");
            }
        }
#if UNITY_EDITOR
        protected new void OnEnable()
        {
            base.OnEnable();
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;

            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }
        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;

                _value = _startValue;
            }
        }
#endif

    }


}
