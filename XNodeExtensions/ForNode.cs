using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class ForNode : NodeControlExecute
    {
        [Input, SerializeField, Min(2)] private int _n = 2;

        [Output(ShowBackingValue.Never), SerializeField] private int _currentIndex;

        private int _i;

        public override void Execute()
        {
            var nPort = GetInputPort(nameof(_n));

            var n = _n;

            if (nPort.Connection != null)
            {
                n = (int)nPort.Connection.GetOutputValue();
            }
            for (_i = 0; _i < n + 1; _i++)
            {
                foreach (var item in GetExitPort().GetConnections())
                {
                    ExecuteNodesFromPort(item);
                }
            }
        }

        public override object GetValue(NodePort port)
        {
            return _i;
        }
    }

    }
