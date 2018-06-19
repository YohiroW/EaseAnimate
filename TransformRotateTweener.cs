using UnityEngine;
using System.Collections;

public class TransformRotateTweener : V3Tweener
{
    protected override void OnUpdate(object sender, System.EventArgs e)
    {
        base.OnUpdate(sender, e);
        transform.rotation = Quaternion.Euler(currentValue);
    }
}
