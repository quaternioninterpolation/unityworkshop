using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
    public Transform projectilePrefab;
    public float nextShootDelay;

    protected Timer shootTimer;

    public Weapon()
    {
        shootTimer = new Timer(nextShootDelay);
    }

    public virtual bool CanFire()
    {
        return shootTimer.IsElapsed();
    }

    public virtual void Update()
    {
        shootTimer.Update(Time.deltaTime);
    }

    public virtual void Fire(BaseEntity owner, Vector3 position, Vector2 direction)
    {
        if (CanFire())
        {
            shootTimer.Reset();

            Transform projectileInstance = GameObject.Instantiate(projectilePrefab, position, Quaternion.identity);

            Projectile projectile = projectileInstance.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.SetData(owner, direction);
            }
        }
    }
}
