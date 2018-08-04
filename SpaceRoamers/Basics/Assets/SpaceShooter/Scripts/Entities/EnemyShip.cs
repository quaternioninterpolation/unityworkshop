using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShip : AIEntity
{
    public bool dontShootAbove = true;
    public Weapon baseWeapon;
    public float awarenessRadius = 16f;
    public int crashEnemyDamage = 10;

    protected BaseEntity target;

    protected override void Awake()
    {
        base.Awake();
        team = 2;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Think()
    {
        base.Think();

        //Shoot at player?
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BaseEntity other = collision.collider?.GetComponent<BaseEntity>();
        if (other != null && other.team != team)
        {
            other.Damage(crashEnemyDamage);
            Kill();
        }
    }

    protected virtual BaseEntity GetEnemy()
    {
        if (target == null || target.gameObject == null)
        {
            target = SearchForEnemy();
        }
        return target;
    }

    protected virtual BaseEntity SearchForEnemy()
    {
        //TODO: Layer masks
        Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, awarenessRadius);

        BaseEntity first = null;
        foreach (var collider in overlappingColliders)
        {
            BaseEntity entity = collider.GetComponent<BaseEntity>();
            if (entity != null && entity != this && entity.team != team && CanShootAtEnemy(entity))
            {
                first = entity;
                break;
            }
        }
        return first;
    }

    protected virtual bool CanShootAtEnemy(BaseEntity entity)
    {
        return entity.transform.position.y <= transform.position.y;
    }
}
