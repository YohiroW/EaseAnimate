using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorTweener : RenderTweener
{
    protected override void OnUpdate(object sender, System.EventArgs e)
    {
        base.OnUpdate(sender, e);
        if(gameObject.GetComponent<Image>() != null)
        {  
            gameObject.GetComponent<Image>().color = currentValue;
        }
        else if (gameObject.GetComponent<Renderer>() != null)
        {
            gameObject.GetComponent<Renderer>().material.color = currentValue;
        }
        else if (gameObject.GetComponent<Text>() != null)
        {
            gameObject.GetComponent<Text>().color = currentValue;
        }
    }
}
