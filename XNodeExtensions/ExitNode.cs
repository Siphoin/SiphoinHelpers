using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class ExitNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            Debug.Log($"node queue from graph {graph.name} finished");
        }
    }
}
