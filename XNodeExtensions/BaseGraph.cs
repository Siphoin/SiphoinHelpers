using XNode;
using UnityEngine;
using System.Collections.Generic;

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


    }
}
