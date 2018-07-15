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
        timer = targetTime;
    }

    public void Update(float time)
    {
        if (timer > 0)
        {
            timer -= Mathf.Max(0, time);
            if (timer == 0)
            {
                callback?.Invoke();
            }
        }
    }

    public bool IsElapsed()
    {
        return timer <= 0;
    }
}
