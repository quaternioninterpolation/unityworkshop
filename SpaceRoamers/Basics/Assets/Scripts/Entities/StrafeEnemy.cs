// // --
// // Author: Josh van den Heever
// // Date: 16/07/2018 @ 10:02 p.m.
// // --
using UnityEngine;
using System.Collections;

public class StrafeEnemy : EnemyShip
{
    public bool canShootDiretlyAtPlayer;
    public Vector2 moveExtents = new Vector2(-7.5f, 7.5f);
    public float moveDuration = 1f;
    public Vector2 shootDelayRange = new Vector2(0.3f, 2f);
    public bool moveRightNext;

    protected Timer moveTimer;
    protected Vector2 startPos;
    protected Vector2 endPos;


    protected override void Awake()
    {
        base.Awake();
        moveTimer = new Timer(moveDuration);
        startPos = transform.position.ToVector2() + Vector2.right * moveExtents.x;
        endPos = transform.position.ToVector2() + Vector2.right * moveExtents.y;
    }

    protected override void Update()
    {
        base.Update();

        //Strafe!
        transform.position = Vector2.Lerp(moveRightNext ? startPos : endPos,
                                          moveRightNext ? endPos : startPos,
                                          moveTimer.GetTimeRatio());
        moveTimer.Update(Time.deltaTime);
        if (moveTimer.IsElapsed())
        {
            moveTimer.Reset();
            moveRightNext = !moveRightNext;
        }
    }

    protected override void Think()
    {
        base.Think();

        BaseEntity enemy = GetEnemy();

        if (enemy != null && CanShootAtEnemy(enemy))
        {
            Vector2 shootDirection = Vector2.down;

            if (canShootDiretlyAtPlayer)
            {
                shootDirection = (enemy.transform.position - transform.position);
            }

            baseWeapon.Fire(this, shootDirection, 0f);

            //Set our next think/fire time
            SetThinkTime(Random.Range(shootDelayRange.x, shootDelayRange.y));
        }
    }

    private void OnDrawGizmos()
    {
        Color original = Gizmos.color;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + Vector3.right * moveExtents.x, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.right * moveExtents.y, 1f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, awarenessRadius);

        Gizmos.color = original;
    }
}
