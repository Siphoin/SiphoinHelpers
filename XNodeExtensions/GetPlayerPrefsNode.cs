using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class GetPlayerPrefsNode : BaseNode
    {
        [SerializeField] private string _key;

        [SerializeField] private FieldType _type;
    }
}
