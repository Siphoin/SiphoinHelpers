using SiphoinUnityHelpers.XNodeExtensions;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Random
{
    public abstract class RandomRangeNode<T> : BaseNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private T _min;

        [Input(connectionType = ConnectionType.Override), SerializeField] private T _max;


        [Output, SerializeField] private T _result;
        public override object GetValue(NodePort port)
        {
            if (!Application.isPlaying)
            {
                return base.GetValue(port);
            }

            float min = float.Parse(_min.ToString());

            float max = float.Parse(_max.ToString());

            var inputMin = GetInputPort(nameof(_min));

            var inputMax = GetInputPort(nameof(_max));

            if (inputMin.Connection != null)
            {
                max = float.Parse(GetDataFromPort<T>(nameof(_min)).ToString());
            }

            if (inputMax.Connection != null)
            {
                max = float.Parse(GetDataFromPort<T>(nameof(_max)).ToString());
            }

            return UnityEngine.Random.Range(min, max);
        }
    }
}
