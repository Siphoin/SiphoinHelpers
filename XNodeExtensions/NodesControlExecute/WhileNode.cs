using Cysharp.Threading.Tasks;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using System;
using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.NodesControlExecutes
{
    [NodeTint("#593d6b")]
    public class WhileNode : AsyncNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private bool _condition;

        public override void Execute()
        {
            base.Execute();

            While().Forget();
        }

        private async UniTask While ()
        {
            while (true)
            {
                StopTask();

                base.Execute();

                bool condition = GetDataFromPort<bool>(nameof(_condition));

                if (condition)
                {
                    foreach (var item in GetExitPort().GetConnections())
                    {
                        ExecuteNodesFromPort(item);
                    }

                    StopTask();

                    break;
                }

                await UniTask.Delay(1, cancellationToken: TokenSource.Token);


            }

            
        }
    }
}
