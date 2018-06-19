using UnityEngine;
using System.Collections;

public class BannerPopEffect : MonoBehaviour
{
    public enum PopAxis
    {
        PA_X,
        PA_Y,
        PA_Z
    };

    public enum AnimateType
    {
        AT_ROTATE,
        AT_MOVE
    };

    //delta alone axis
    public float originDelta;
    //
    public float durationTime;
    //
    public PopAxis axisToPop;

    public AnimateType animateToPlay;

    private float delta;

    protected Vector3 originLocation;

    protected Quaternion originRotation;
    // Use this for initialization
    void Start()
    {
        originLocation = transform.localPosition;
        originRotation = transform.localRotation;
    }

    IEnumerator easePopOut()
    {
        float start = transform.localPosition.x;
        float end = start + delta;
        float duration = durationTime;
        float currentTime = 0;

        if (end > originLocation.x + originDelta || end < originLocation.x)
        {
            currentTime = duration;
        }

        while (currentTime < duration)
        {
            yield return new WaitForEndOfFrame();
            currentTime = Mathf.Clamp(currentTime += Time.deltaTime, 0, duration);

            float valueX = EaseAnimate.EaseInSine(start, end, currentTime / duration);
            transform.localPosition = new Vector3(valueX, transform.localPosition.y, transform.localPosition.z);
        }
    }

    IEnumerator easeRotating()
    {
        float start = transform.localRotation.x;
        float end = start + delta;
        float duration = durationTime;
        float currentTime = 0;

        while (currentTime < duration)
        {
            yield return new WaitForEndOfFrame();
            currentTime = Mathf.Clamp(currentTime += Time.deltaTime, 0, duration);

            float valueX = EaseAnimate.EaseOutBounce(start, end, currentTime / duration);
            transform.localRotation = Quaternion.Euler(valueX * 5.0f, valueX * 3.8f, valueX * 3.5f);
        }
    }

    private void rotateWithMouse()
    {
        Vector2 m_RotateDelta = Vector2.zero;
        m_RotateDelta = Vector2.Lerp(m_RotateDelta, new Vector2(3, 3), Time.deltaTime * 4.0f);

        transform.rotation =
               originRotation * Quaternion.Euler(-m_RotateDelta.y * 3, m_RotateDelta.x * 3, 0);
    }

}
