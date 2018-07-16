using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float targetTime;
    private float timer;
    private System.Action callback;

    public Timer()
        : this(0f)
    {
    }

    public Timer(float duration)
        : this(duration, null)
    {
    }

    public Timer(float duration, System.Action callback)
    {
        this.targetTime = duration;
        this.callback = callback;
        Reset();
    }

    public void SetTargetTime(float duration)
    {
        this.targetTime = duration;
        Reset();
    }

    public void SetElapsedCallback(System.Action callback)
    {
        this.callback = callback;
    }

    public void Reset()
    {
        timer = 0f;
    }

    public void Update(float time)
    {
        if (timer < targetTime)
        {
            timer = Mathf.Min(timer+time, targetTime);
            if (timer >= targetTime)
            {
                callback?.Invoke();
            }
        }
    }

    public bool IsElapsed()
    {
        return timer >= targetTime;
    }

    public float GetTime()
    {
        return timer;
    }

    public float GetTimeRatio()
    {
        return targetTime != 0f ? timer / targetTime : 1f;
    }
}
