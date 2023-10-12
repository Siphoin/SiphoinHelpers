using System.Linq;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class ForNode : BaseNodeInteraction
    {
        [SerializeField, Min(2)] private int _n = 2;

        public override void Execute()
        {
            for (int i = 0; i < _n; i++)
            {
                foreach (var item in GetExitPort().GetConnections())
                {
                    var node = item.node as BaseNode;

                    node.Execute();
                }
            }
        }
        }

    }
