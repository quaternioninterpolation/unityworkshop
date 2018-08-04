using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeEnemyPart : BaseEntity 
{
    public Weapon weapon;

    public void SetParent(BaseEntity parent)
    {
        team = parent.team;
    }

    public void FireWeapon(BaseEntity target)
    {
        Vector2 direction = (target.transform.position - weapon.transform.position).normalized;
        weapon?.Fire(this, direction, 0f);
    }
}
