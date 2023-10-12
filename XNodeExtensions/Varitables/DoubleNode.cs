using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class DoubleNode : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private double _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}