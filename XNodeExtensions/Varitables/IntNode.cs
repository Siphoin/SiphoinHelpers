using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class IntNode : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private int _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}