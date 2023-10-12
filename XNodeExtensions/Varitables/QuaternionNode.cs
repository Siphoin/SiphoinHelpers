using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables
{
    public class QuaternionNode : BaseNode
    {
        [SerializeField, Output(ShowBackingValue.Always)] private Quaternion _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}