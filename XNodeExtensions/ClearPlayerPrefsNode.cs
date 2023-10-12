using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class ClearPlayerPrefsNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
