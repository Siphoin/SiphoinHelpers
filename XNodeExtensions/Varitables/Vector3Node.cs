using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class Vector3Node : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private Vector3 _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}