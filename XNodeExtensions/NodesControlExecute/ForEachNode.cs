using Mono.Cecil;
using System.Collections;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.NodesControlExecutes
{
    public class ForEachNode : NodeControlExecute
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private NodePortEnumerable _enumerable;

        [Output(ShowBackingValue.Never), SerializeField] private NodePort _operations;

        [Space(10)]

        [Output(ShowBackingValue.Never), SerializeField] private Object  _outputElement;

        private object _currentElement;

        public override object GetValue(NodePort port)
        {
            return _currentElement;
        }

        public override void Execute()
        {
            var enumerable = GetDataFromPort<IEnumerable>(nameof(_enumerable));

            foreach (var item in enumerable)
            {
                _currentElement = item;

                var operations = GetOutputPort(nameof(_operations)).GetConnections();

                if (operations != null)
                {
                    foreach (var itemNode in operations)
                    {
                        ExecuteNodesFromPort(itemNode);
                    }
                }

               



            }
        }
    }
}
