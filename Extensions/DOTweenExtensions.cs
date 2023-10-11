using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace SiphoinUnityHelpers.Extensions
{
    public static class DOTweenExtensions
    {
        public static TweenerCore<Color, Color, ColorOptions> DOColor(this MainModule target, Color endValue, float duration)
        {
            TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => target.startColor.color, delegate (Color x)
            {
                target.startColor = x;
            }, endValue, duration);
            tweenerCore.SetTarget(target);
            return tweenerCore;
        }
    }
}
