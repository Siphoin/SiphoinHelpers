using SiphoinUnityHelpers.Attributes;
using UnityEngine;
namespace SiphoinUnityHelpers.XNodeExtensions.PlayerPrefsSystem
{
    public class DeleteKeyFromPlayerPrefsNode : BaseNodeInteraction
    {
        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private string _key;

        public override void Execute()
        {
            if (PlayerPrefs.HasKey(_key))
            {
                PlayerPrefs.DeleteKey(_key);
            }
        }
    }
}
