using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float linearSpeed;
    public int damage;
    protected int team;
    
    public virtual void SetData(BaseEntity owner, Vector2 direction)
    {
        this.team = owner.team;

        //Set initial velocity
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            rigidbody2D.velocity = direction.normalized * linearSpeed;
        }

        //Ignore collision between this and the owner
        Collider2D ownerCollider = owner.GetComponent<Collider2D>();
        if (ownerCollider != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ownerCollider);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BaseEntity hitEntity = collision.collider?.GetComponent<BaseEntity>();

        if (hitEntity != null && hitEntity.team != team)
        {
            hitEntity.Damage(damage);
        }

        //Destroy the projectile once we're done
        Destroy(gameObject);
    }
}
