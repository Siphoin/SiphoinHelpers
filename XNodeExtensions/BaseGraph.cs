using XNode;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    [CreateAssetMenu]
    public class BaseGraph : NodeGraph
    {
        private NodeQueue _queue;

        private BaseNode _currentNode;

        

        public void Execute ()
        {
            var queue = new List<BaseNodeInteraction>();


            for (int i = 0; nodes.Count > i; i++)
            {
                var node = nodes[i];

                if (node is BaseNodeInteraction)
                {
                    queue.Add(node as BaseNodeInteraction);
                }
            }

            _queue = new NodeQueue(this, queue);

            ExecuteProcess().Forget();


        }

        public BaseNode GetNodeByGuid (string guid)
        {
            foreach (var node in from item in nodes
                                 let node = item as BaseNode
                                 where node.GUID == guid
                                 select node)
            {
                return node;
            }

            return null;
        }

        private async UniTask ExecuteProcess ()
        {

            _queue.OnEnd += ReportEnd;

            for (int i = 0; _queue.Count > i; i++)
            {
                await _queue.Next();
            }
        }

        private void ReportEnd()
        {
            _queue.OnEnd -= ReportEnd;

            Debug.Log($"graph {name} end execute");
        }
    }
}
