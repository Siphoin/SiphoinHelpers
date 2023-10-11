using System;
using UnityEditor;
using UnityEngine;

namespace SiphoinUnityHelpers.AdaptiveBuild
{
    internal static class AdaptiveBuilder
    {
        private const string PATH_BUILD = "Builds/";

        [MenuItem("Adaptive Builder/Windows Application")]
        private static void BuildWindowsApplication()
            => Build(BuildType.Application);

        [MenuItem("Adaptive Builder/Dedicated Server | Windows")]
        private static void BuildDedicatedServerWindows() 
            => Build(BuildType.DedicatedServer);

        [MenuItem("Adaptive Builder/Dedicated Server | Linux")]
        private static void BuildDedicatedServerLinux()
            => Build(BuildType.DedicatedServer, PlatformType.Linux);



        private static void Build (BuildType buildType, PlatformType platform = PlatformType.Windows)
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

            buildPlayerOptions.locationPathName = $"{PATH_BUILD}{buildType}_{platform}/{Application.productName}_{buildType}.exe";

            switch (platform)
            {
                case PlatformType.Windows:
                    buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
                    break;
                case PlatformType.Linux:
                    buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
                    break;
                default:
                    throw new ArgumentException($"platform {platform} is invalid");
            }

            buildPlayerOptions.scenes = new string[EditorBuildSettings.scenes.Length];

            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                buildPlayerOptions.scenes[i] = EditorBuildSettings.scenes[i].path;
            }

            if (buildType == BuildType.DedicatedServer)
            {
                buildPlayerOptions.subtarget = (int)StandaloneBuildSubtarget.Server;
            }


            BuildPipeline.BuildPlayer(buildPlayerOptions);


            
        }
    }
}
