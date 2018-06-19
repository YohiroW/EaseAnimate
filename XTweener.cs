using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace XTweener
{
    public static class ExtensionTweener
    {
        public static EaseTweener MoveTo(this Transform t, Vector3 position)
        {
            return MoveTo(t, position, EaseTweener.defaultDuration);
        }

        public static EaseTweener MoveTo(this Transform t, Vector3 position, float duration)
        {
            return MoveTo(t, position, duration, EaseTweener.defaultAnimProperties);
        }

        public static EaseTweener MoveTo(this Transform t, Vector3 position, float duration, Func<float, float, float, float> animProperties)
        {
            TransformPosTweener tweener = t.gameObject.AddComponent<TransformPosTweener>();
            tweener.originValue = t.position;
            tweener.finalValue = position;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();
            return tweener;
        }

        public static EaseTweener MoveToLocal(this Transform t, Vector3 position)
        {
            return MoveToLocal(t, position, EaseTweener.defaultDuration);
        }

        public static EaseTweener MoveToLocal(this Transform t, Vector3 position, float duration)
        {
            return MoveToLocal(t, position, duration, EaseTweener.defaultAnimProperties);
        }

        public static EaseTweener MoveToLocal(this Transform t, Vector3 position, float duration, Func<float, float, float, float> animProperties)
        {
            TransformLocalPosTweener tweener = t.gameObject.AddComponent<TransformLocalPosTweener>();
            tweener.originValue = t.localPosition;
            tweener.finalValue = position;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();
            return tweener;
        }

        public static EaseTweener ScaleTo(this Transform t, Vector3 scale)
        {
            return MoveTo(t, scale, EaseTweener.defaultDuration);
        }

        public static EaseTweener ScaleTo(this Transform t, Vector3 scale, float duration)
        {
            return MoveTo(t, scale, duration, EaseTweener.defaultAnimProperties);
        }

        public static EaseTweener ScaleTo(this Transform t, Vector3 scale, float duration, Func<float, float, float, float> animProperties)
        {
            TransformScaleTweener tweener = t.gameObject.AddComponent<TransformScaleTweener>();
            tweener.originValue = t.localScale;
            tweener.finalValue = scale;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();
            return tweener;
        }

        public static EaseTweener RotateTo(this Transform t, Vector3 euler, float duration, Func<float,float,float,float> animProperties)
        {
            TransformRotateTweener tweener = t.gameObject.AddComponent<TransformRotateTweener>();
            tweener.originValue = new Vector3(t.gameObject.transform.rotation.x,
                                            t.gameObject.transform.rotation.y,
                                            t.gameObject.transform.rotation.z);
            tweener.finalValue = euler;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();

            return tweener;
        }

        public static EaseTweener RotateTo(this Transform t, Vector3 euler)
        {
            return RotateTo(t, euler, EaseTweener.defaultDuration, EaseAnimate.Linear);
        }

        public static EaseTweener RotateTo(this Transform t, Vector3 euler, float duration)
        {
            return RotateTo(t, euler, duration, EaseAnimate.Linear);
        }

        public static EaseTweener RotateToLocal(this Transform t, Vector3 euler, float duration, Func<float, float, float, float> animProperties)
        {
            TransformLocalRotateTweener tweener = t.gameObject.AddComponent<TransformLocalRotateTweener>();
            tweener.originValue = new Vector3(t.gameObject.transform.rotation.x,
                                            t.gameObject.transform.rotation.y,
                                            t.gameObject.transform.rotation.z);
            tweener.finalValue = euler;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();

            return tweener;
        }

        public static EaseTweener ColorFadeTo(this Renderer render, Color colorFadeTo, float duration, Func<float, float, float, float> animProperties)
        {
            ColorTweener tweener = render.gameObject.AddComponent<ColorTweener>();
            tweener.originValue = render.material.color;
            tweener.finalValue = colorFadeTo;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();

            return tweener;
        }

        public static EaseTweener ColorFadeTo(this Image render, Color colorFadeTo, float duration, Func<float, float, float, float> animProperties)
        {
            ColorTweener tweener = render.gameObject.AddComponent<ColorTweener>();
            tweener.originValue = render.color;
            tweener.finalValue = colorFadeTo;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();

            return tweener;
        }

        public static EaseTweener ColorFadeTo(this Text render, Color colorFadeTo, float duration, Func<float, float, float, float> animProperties)
        {
            ColorTweener tweener = render.gameObject.AddComponent<ColorTweener>();
            tweener.originValue = render.color;
            tweener.finalValue = colorFadeTo;
            tweener.controller.duration = duration;
            tweener.controller.animatePreperties = animProperties;
            tweener.controller.play();

            return tweener;
        }

    }
}


