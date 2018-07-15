using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : AIEntity
{
    public Transform projectile;
    public float shootReloadDuration;

    private Timer fireTimer;

    protected override void Awake()
    {
        base.Awake();
        team = 2;
    }

    protected override void Think()
    {
        base.Think();
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        //Spawn an explosion
    }
}
