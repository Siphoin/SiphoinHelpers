using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Random
{
    public class RandomIntNode : BaseNode
    {

        [Input(ShowBackingValue.Always), SerializeField] private int _min;
        [Input(ShowBackingValue.Always), SerializeField] private int _max;

        [Output, SerializeField] private NodePort _result;


        public override object GetValue(NodePort port)
        {
            return UnityEngine.Random.Range(_min, _max + 1);
        }


    }
}
