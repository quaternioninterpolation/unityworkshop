using UnityEngine;
using System.Collections;

public abstract class GameModeBase<T> : SingletonMonobehaviour<T> where T : GameModeBase<T>
{
    protected override void Awake()
    {
        Reset();
    }

    public virtual void Reset()
    {
        //Stub
    }
}
