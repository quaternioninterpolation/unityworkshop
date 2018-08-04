using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour {
    public int maxHealth = 10;
    public int team;
    public Transform[] spawnOnDeath;

    protected System.Action destroyCallback;
    protected int _health;
    public int health
    {
        set
        {
            int lastHealth = _health;
            _health = Mathf.Clamp(value, 0, maxHealth);
            if (lastHealth > 0 && _health == 0)
            {
                OnDeath();
            }
        }
        get
        {
            return _health;
        }
    }

    public void SetDestroyCallback(System.Action callback)
    {
        this.destroyCallback = callback;
    }

    protected virtual void Awake()
    {
        Reset();
    }

    public virtual void Reset()
    {
        health = maxHealth;
    }

    public virtual void OnRespawn()
    {
        Reset();
    }

    public void Kill()
    {
        health = 0;
    }

    protected virtual void OnDeath()
    {
        if (spawnOnDeath != null && spawnOnDeath.Length > 0)
        {
            foreach(var prefab in spawnOnDeath)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }

        destroyCallback?.Invoke();
        Destroy(gameObject);
    }

    //TODO: Pass through type of damage, or the entity responsible for the damage.
    public virtual void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    public virtual bool IsAlive()
    {
        return health > 0;
    }
}
