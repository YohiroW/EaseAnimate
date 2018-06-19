using UnityEngine;
using System.Collections;

public class TransformScaleTweener : V3Tweener
{
    protected override void OnUpdate(object sender, System.EventArgs e)
    {
        base.OnUpdate(sender, e);
        transform.localScale = currentValue;
    }


}
