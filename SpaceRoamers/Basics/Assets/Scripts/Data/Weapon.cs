using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public Transform projectilePrefab;
    public float nextShootDelay;

    protected Timer shootTimer;

    protected virtual void Awake()
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

    public virtual void Fire(BaseEntity owner, Vector2 direction, float inheritedSpeed)
    {
        if (CanFire())
        {
            shootTimer.Reset();

            Transform projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Projectile projectile = projectileInstance.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.SetData(owner, direction, inheritedSpeed);
            }
        }
    }
}
