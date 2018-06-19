using UnityEngine;
using System.Collections;
using System;

public class TransformPosTweener : V3Tweener
{
    protected override void OnUpdate(object sender, System.EventArgs e)
    {
        base.OnUpdate(sender, e);
        transform.position = currentValue;
    }
}
