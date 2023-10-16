using XNode;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    [CreateAssetMenu]
    public class BaseGraph : NodeGraph
    {
        public NodeQueue GetQueue ()
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

            return new NodeQueue(this, queue);
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


    }
}
