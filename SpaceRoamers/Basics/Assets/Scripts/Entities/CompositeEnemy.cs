using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeEnemy : StrafeEnemy 
{
    private CompositeEnemyPart[] parts;

    protected override void Awake()
    {
        base.Awake();

        //Get all child parts
        parts = GetComponentsInChildren<CompositeEnemyPart>();
        foreach (var part in parts)
        {
            part.SetDestroyCallback(OnPartDestroyed);
            part.SetParent(this);
        }
    }

    protected override void Think()
    {
        base.Think();

        if (target != null)
        {
            foreach (var part in parts)
            {
                if (part != null && part.gameObject != null && part.IsAlive())
                {
                    part.FireWeapon(target);
                }
            }
        }
    }

    protected virtual void OnPartDestroyed()
    {
        //Count remaining
        int remaining = 0;
        foreach (var part in parts)
        {
            if (part.IsAlive())
                ++remaining;
        }

        if (remaining == 0)
        {
            Kill();
        }
        else
        {
            //Update our parts
            parts = GetComponentsInChildren<CompositeEnemyPart>();
        }
    }

    public override void Damage(int damageAmount)
    {
        //base.Damage(damageAmount);
        //Don't damage the main body
    }
}
