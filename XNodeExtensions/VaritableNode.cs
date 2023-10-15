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

        [Space(25)]

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private Color32 _color = UnityEngine.Color.white;

        public string Name { get => _name; set => _name = value; }
        public Color32 Color { get => _color; set => _color = value; }

        public abstract object GetStartValue();

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            name = Color.ToColorTag($"{Name} ({GetDefaultName()})");
        }
#endif

    }

    public abstract class VaritableNode<T> : VaritableNode
    {
       private T _startValue;

        [Space(10)]

        [SerializeField, Output(ShowBackingValue.Always), ReadOnly(ReadOnlyMode.OnEditor)] private T _value;
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


        private void Awake()
        {
            Name = $"{GetDefaultName()} Varitable";
        }
#if UNITY_EDITOR

        protected override void OnValidate()
        {
            base.OnValidate();

            Validate();
        }

        private void Validate()
        {
            if (!Application.isPlaying)
            {
                if (string.IsNullOrEmpty(Name))
                {
                    Name = $"{GetDefaultName()} Varitable";
                }
                _startValue = _value;
            }
        }
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
