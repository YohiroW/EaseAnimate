using UnityEngine;
using System.Collections;
using System;

public enum TimeUpdateType
{
    NORMAL,
    FIXED,
    REALTIME
}

public enum AnimateState
{
    STOP,
    PAUSE,
    PLAYING,    
    REVERSE
}

public enum AnimateFinishState
{
    RESET,
    CONSTANT
}

public enum AnimateLoopType
{
    REPEAT,
    PINGPONG
}

public class EaseController : MonoBehaviour 
{
    //
    public event EventHandler eventUpdate;

    public event EventHandler eventStateChanged;

    public event EventHandler eventFinished;

    public event EventHandler eventLooping;
    //base info define
    public float duration =  1.0f;

    public int loopCount = 0;

    public float originValue = 0.0f;

    public float finalValue = 1.0f;
    //a delegate contacter params means
    //1. current time
    //2. value which getted by EaseAnimate
    //3. offset changed by last frame 
    //4. repeat times
    public Func<float, float, float, float> animatePreperties = EaseAnimate.Linear;

    public float currentTime { get; set; }

    public float currentValue { get; set; }

    public float currentOffSet { get; set; }

    public int loops { get; private set;}

    //anim state settings
    public AnimateState currentAnimState { get; private set; }

    public AnimateState preAnimState { get; private set; }

    public TimeUpdateType timeType = TimeUpdateType.NORMAL;

    public AnimateFinishState finishState = AnimateFinishState.CONSTANT;

    public AnimateLoopType loopType = AnimateLoopType.REPEAT;

    public bool isAnimPlaying 
    {
        get
        {
            return currentAnimState == AnimateState.PLAYING || currentAnimState == AnimateState.REVERSE; 
        }
    }

    void OnEnable()
    {
        resume();
    }

    void OnDisable()
    {
        pause();
    }

    public void setPlayState(AnimateState targetState)
    {
        if (targetState == currentAnimState)
        {
            return;
        }
        preAnimState = currentAnimState;
        currentAnimState = targetState;

        if (eventStateChanged != null)
        {
            eventStateChanged(this, EventArgs.Empty);
        }

        StopCoroutine("ticker");
        if (isAnimPlaying)
        {
            //Debug.Log("Couroutine begin .. ");
            StartCoroutine("ticker");
        }
    }

    public void play()
    {
        setPlayState(AnimateState.PLAYING);
    }

    public void pause()
    {
        setPlayState(AnimateState.PAUSE);
    }

    public void resume()
    {
        setPlayState(preAnimState);
    }
    
    public void reverse()
    {
        setPlayState(AnimateState.REVERSE);
    }

    public void stop()
    {
        setPlayState(AnimateState.STOP);
        //clean loop counter
        loops = 0;
        if (finishState == AnimateFinishState.RESET)
        {
            skipToBegin();
        }
        //StopCoroutine("ticker");
    }

    public void skipToBegin()
    {
        skipTo(0);
    }

    public void skipToEnd()
    {
        skipTo(duration);
    }

    public void skipTo(float time)
    {
        currentTime = Mathf.Clamp01(time / duration);
        float targetValue = (finalValue - originValue) * currentTime + originValue;
        currentOffSet = targetValue - currentValue;
        currentValue = targetValue;

        if (eventUpdate != null)
        {
            eventUpdate(this, EventArgs.Empty);
        }
    }

    public IEnumerator ticker()
    {
        while (true)
        {
            switch(timeType)
            {
                case TimeUpdateType.NORMAL:
                    yield return new WaitForEndOfFrame();
                    tick(Time.deltaTime);
                    break;
                case TimeUpdateType.FIXED:
                    yield return new WaitForFixedUpdate();
                    tick(Time.fixedDeltaTime);
                    break;
                case TimeUpdateType.REALTIME:
                    yield return new WaitForEndOfFrame();
                    tick(Time.unscaledDeltaTime);
                    break;
            }
        }
    }

    public void tick(float time)
    {
        bool isFinished = false;
        
        if(currentAnimState == AnimateState.PLAYING)
        {
            currentTime = Mathf.Clamp01(currentTime + time/duration);
            isFinished = Mathf.Approximately(currentTime, 1.0f);
        }
        else
        {
            currentTime = Mathf.Clamp01(currentTime - time/duration);
            isFinished = Mathf.Approximately(currentTime, 0.0f);
        }

        float frameValue = (finalValue - originValue) * animatePreperties(0.0f, 1.0f, currentTime) + originValue;
        currentOffSet = frameValue - currentValue;
        currentValue = frameValue;

        if (eventUpdate != null)
        {
            //dispatch msg to delegate pointed
            eventUpdate(this, EventArgs.Empty);
        }

        if (isFinished)
        {
            loops++;
            if (loopCount < 0 || loopCount >= loops)
            {
                if (loopType == AnimateLoopType.REPEAT)
                {
                    skipToBegin();
                }
                else
                {
                    setPlayState(currentAnimState == AnimateState.PLAYING ? AnimateState.REVERSE : AnimateState.PLAYING);
                }

                if (eventLooping != null)
                {
                    eventLooping(this, EventArgs.Empty);
                }
            }
            else
            {
                if (eventFinished != null)
                {
                    eventFinished(this, EventArgs.Empty);
                }
                stop();
            }
        }
    }

}

