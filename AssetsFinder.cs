#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SiphoinUnityHelpers
{
    public static class AssetsFinder
    {
        public static IEnumerable<T> LoadAssets<T>(string path, string extensionAsset) where T : UnityEngine.Object
        {

            Type type = typeof(T);

            List<T> result = new List<T>();

            List<string> fileNames = new List<string>();

            var filesMain = Directory.GetFiles(path, $"*.{extensionAsset}");

            var directories = Directory.GetDirectories(path);

            fileNames.AddRange(filesMain);

            foreach (var item in directories)
            {
                string[] files = Directory.GetFiles(item, $"*.{extensionAsset}");

                fileNames.AddRange(files);
            }

            for (int i = 0; i < fileNames.Count; i++)
            {
                T asset = AssetDatabase.LoadAssetAtPath(fileNames[i], type) as T;

                result.Add(asset);
            }

            return result;
        }
    }
}
#endif

