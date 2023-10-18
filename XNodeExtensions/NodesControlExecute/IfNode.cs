using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.NodesControlExecutes
{
    public class IfNode : NodeControlExecute
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private bool _condition;
 
        [Output, SerializeField] private NodePort _true;

        [Output, SerializeField] private NodePort _false;

        public override void Execute()
        {
            var condition = GetDataFromPort<bool>(nameof(_condition));

            string portName = $"_{condition}";

            portName = portName.ToLower();

            NodePort targetPort = GetOutputPort(portName);

            var connections = targetPort.GetConnections();


            if (connections != null)
            {
                foreach (var item in connections)
                {
                    var node = item.node as BaseNode;

                    node.Execute();
                }
            }
        }
    }
}
