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
            List<BaseNodeInteraction> queue = new List<BaseNodeInteraction>();

            for (int i = 0; nodes.Count > i; i++)
            {
                if (nodes[i] is BaseNodeInteraction)
                {
                    queue.Add(nodes[i] as BaseNodeInteraction);
                }
            }

            return new NodeQueue(queue);
        }
    }
}
