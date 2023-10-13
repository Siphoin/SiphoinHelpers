using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class NodeQueue
    {
        private int _index;

        private List<BaseNodeInteraction> _nodes;

        private Dictionary<string, object> _varitables;

        public event Action OnEnd;

        public int Count => _nodes.Count;


        public NodeQueue(BaseGraph parentGraph, IEnumerable<BaseNodeInteraction> nodes)
        {
            _nodes = nodes.Where(x => x.Enabled).OrderBy(x => x.position.x).ToList();


            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"New Node Queue from node graph {parentGraph.name}:\n");

            foreach (var node in _nodes)
            {
                stringBuilder.AppendLine(node.name);
            }

            Debug.Log(stringBuilder.ToString());
        }

        public BaseNode Next ()
        {
            int currentIndex = _index;

            var node = _nodes[currentIndex];

            node.Execute();

            if (node.Outputs.Count() > 0)
            {
                _index++;
            }

            else
            {
                OnEnd?.Invoke();

                return null;
            }

            return node;
        }
    }
}
