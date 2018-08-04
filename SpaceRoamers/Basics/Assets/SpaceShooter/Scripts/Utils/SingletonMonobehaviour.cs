using UnityEngine;
using System.Collections;

public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T sInstance = null;

    public static T Instance
    {
        get
        {
            return sInstance;
        }
    }

    protected virtual void Awake()
    {
        sInstance = this as T;
    }
}
