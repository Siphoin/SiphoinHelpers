using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class LongNode : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private long _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}