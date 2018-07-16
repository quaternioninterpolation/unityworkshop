using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEntity : BaseEntity
{
    public float thinkTime = 1f;

    protected Timer thinkTimer;

    protected override void Awake()
    {
        base.Awake();
        thinkTimer = new Timer(thinkTime);
        thinkTimer.SetElapsedCallback(Think);
    }

    public virtual void SetThinkTime(float thinkTime)
    {
        this.thinkTime = thinkTime;
        thinkTimer.SetTargetTime(thinkTime);
    }

    protected virtual void Update()
    {
        thinkTimer.Update(Time.deltaTime);
    }

    protected virtual void Think()
    {
        thinkTimer.Reset();
    }
}
