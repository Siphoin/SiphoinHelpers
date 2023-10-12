using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class Vector2Node : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private Vector2 _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}