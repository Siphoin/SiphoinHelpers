
using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.UnityApplication
{
    [CreateNodeMenu("Siphoin Unity Helpers/X Node Extensions/Application/Quit")]
    public class ApplicationQuitNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            Application.Quit();
        }
    }
}
