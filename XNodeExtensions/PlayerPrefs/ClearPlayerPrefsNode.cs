using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.PlayerPrefsSystem
{
    public class ClearPlayerPrefsNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
