using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class FloatNode : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private float _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}