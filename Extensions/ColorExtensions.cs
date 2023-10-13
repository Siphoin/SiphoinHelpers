using UnityEngine;

namespace SiphoinUnityHelpers.Extensions
{
    public static class ColorExtensions
    {
        public static string ToColorTag (this Color color, string source = "")
        {
            string hex = ColorUtility.ToHtmlStringRGB (color);

            return $"<color=#{hex}>{source}</color>";
        }
    }
}
