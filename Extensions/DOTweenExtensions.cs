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

        public static TweenerCore<float, float, FloatOptions> DOValue(this ProgressBar target, float endValue, float duration, bool snapping = false)
        {
            TweenerCore<float, float, FloatOptions> t = DOTween.To(() => target.Value, x => target.Value = x, endValue, duration);
            t.SetOptions(snapping).SetTarget(target);
            return t;
        }
    }
}
