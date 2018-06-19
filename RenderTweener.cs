using UnityEngine;
using System.Collections;
using System;

public class RenderTweener : EaseTweener 
{
    public Color originValue;

    public Color finalValue;

    public Color currentValue { get; private set; }

    protected override void OnUpdate(object sender, EventArgs e)
    {
        currentValue = (finalValue - originValue) * controller.currentValue + originValue;
    }
}
