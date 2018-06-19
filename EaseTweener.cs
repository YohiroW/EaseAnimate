using UnityEngine;
using System.Collections;
using System;

public abstract class EaseTweener : MonoBehaviour
{
    #region properties
    public static float defaultDuration = 1.0f;

    public static Func<float, float, float, float> defaultAnimProperties = EaseAnimate.EaseInOutQuad;

    public EaseController controller;

    public bool destroyOnFinish = true;
    #endregion

    #region monoPart
    protected virtual void Awake()
    {
        controller = gameObject.AddComponent<EaseController>();
    }

    protected virtual void OnEnable()
    {
        controller.eventUpdate += OnUpdate;
        controller.eventFinished += OnComplete;
    }

    protected virtual void OnDisable()
    {
        controller.eventUpdate -= OnUpdate;
        controller.eventFinished -= OnComplete;
    }

    protected virtual void OnDestroy()
    {
        if (controller != null)
        {
            Destroy(controller);
        }
    }
    #endregion

    #region event handler
    protected abstract void OnUpdate(object sender, EventArgs e);

    protected virtual void OnComplete (object sender, EventArgs e)
    {
        if (destroyOnFinish)
            Destroy(this);
    }
    #endregion

}
