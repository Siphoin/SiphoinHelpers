using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    [NodeTint("#5c2b2b")]
    public class ExitNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            Debug.Log($"node queue from graph {graph.name} finished");
        }
    }
}
