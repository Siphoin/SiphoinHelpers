using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class StringNode : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private string _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}
