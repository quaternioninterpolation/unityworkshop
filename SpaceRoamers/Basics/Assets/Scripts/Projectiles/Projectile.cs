using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float linearSpeed;
    public int damage;
    protected int team;
    public float destroyDelay = 1f;
    public Transform spawnOnDestroy;

    public Timer destroyTimer;

    private void Awake()
    {
        Destroy(gameObject, destroyDelay);
    }

    public virtual void SetData(BaseEntity owner, Vector2 direction, float inheritSpeed)
    {
        this.team = owner.team;

        //Angle to face

        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation + 90f);

        //Set initial velocity
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            rigidbody2D.velocity = direction.normalized * (linearSpeed + Mathf.Max(0f, inheritSpeed));
        }

        //Ignore collision between this and the owner
        Collider2D ownerCollider = owner.GetComponent<Collider2D>();
        if (ownerCollider != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ownerCollider);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        BaseEntity hitEntity = collision.collider?.GetComponent<BaseEntity>();
        
        if (hitEntity != null && hitEntity.team != team)
        {
            hitEntity.Damage(damage);
        }
        
        //Destroy the projectile once we're done
        Destroy(gameObject);
        Instantiate(spawnOnDestroy, transform.position, Quaternion.identity);
    }
}
