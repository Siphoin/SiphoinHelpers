using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Random
{
    [NodeTint("#6b3d5c")]
    public class RandomFloatNode : BaseNode
    {

        [Input(ShowBackingValue.Always), SerializeField] private float _min;
        [Input(ShowBackingValue.Always), SerializeField] private float _max;

        [Output, SerializeField] private NodePort _result;


        public override object GetValue(NodePort port)
        {
            return UnityEngine.Random.Range(_min, _max + 1);
        }
    }
}
