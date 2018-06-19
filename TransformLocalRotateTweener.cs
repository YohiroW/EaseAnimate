using UnityEngine;
using System.Collections;
using XTweener;

public class TransformLocalRotateTweener : V3Tweener
{
    protected override void OnUpdate(object sender, System.EventArgs e)
    {
        base.OnUpdate(sender, e);
        transform.localRotation = Quaternion.Euler(currentValue);     
    }

}
