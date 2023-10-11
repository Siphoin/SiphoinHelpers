using System;
using UnityEngine;

namespace SiphoinUnityHelpers.Extensions
{
    public static class Texture2DExtensions
    {
        public static Texture2D Flip (this Texture2D texture)
        {
            Texture2D flippedTexture = new Texture2D(texture.width, texture.height);

            for (int y = 0; y < texture.height; y++)
            {
                Color[] rowColors = texture.GetPixels(0, y, texture.width, 1);

                Array.Reverse(rowColors);

                flippedTexture.SetPixels(0, texture.height - y - 1, texture.width, 1, rowColors);
            }

            flippedTexture.Apply();

            return flippedTexture;
        }
    }
}
