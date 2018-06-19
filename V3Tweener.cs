using UnityEngine;
using System.Collections;
using System;

public class V3Tweener : EaseTweener
{
    public Vector3 originValue;

    public Vector3 finalValue;

    public Vector3 currentValue { get; private set; }

    protected override void OnUpdate(object sender, EventArgs e)
    {
        currentValue = (finalValue - originValue) * controller.currentValue + originValue;
    }
}
