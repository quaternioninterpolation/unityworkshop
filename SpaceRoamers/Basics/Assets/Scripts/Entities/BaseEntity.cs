using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour {
    public int maxHealth = 10;
    public int team;
    public Transform spawnOnDeath;

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
        if (spawnOnDeath != null)
        {
            Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    //TODO: Pass through type of damage, or the entity responsible for the damage.
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }
}
