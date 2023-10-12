﻿using Trisibo;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SiphoinUnityHelpers.XNodeExtensions
{
    public class LoadSceneNode : BaseNodeInteraction
    {
        [SerializeField] private string _sceneName;

        [SerializeField] private bool _isAsync;

        public override void Execute()
        {
            if (_isAsync)
            {
                SceneManager.LoadSceneAsync(_sceneName);
            }

            else
            {
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}
