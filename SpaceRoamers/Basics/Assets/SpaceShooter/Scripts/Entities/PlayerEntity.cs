using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : BaseEntity
{
    public Vector2 maxVelocity = new Vector2(5f, 5f);
    public Vector2 acceleration = new Vector2(10f, 4f);
    public Vector2 dragMultiplier = new Vector2(6f, 3f);

    public Weapon baseWeapon;

    protected Rigidbody2D rb;

    public Vector2 velocity;
    public Vector2 targetVelocity;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        team = 1;
    }

    protected void ProcessMovementDirection(bool isPressed, Vector2 direction, ref Vector2 output)
    {
        bool isX = Mathf.Abs(direction.x) > Mathf.Abs(direction.y);
        if (isPressed)
        {
            output += direction * acceleration;
        }
    }

    /// <summary>
    /// Updates at a regular interval before physics is calculated
    /// </summary>
    protected void Update()
    {
        targetVelocity.Set(0f,0f);

        ProcessMovementDirection(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow), Vector2.left, ref targetVelocity);
        ProcessMovementDirection(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightAlt), Vector2.right, ref targetVelocity);
        ProcessMovementDirection(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow), Vector2.up, ref targetVelocity);
        ProcessMovementDirection(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow), Vector2.down, ref targetVelocity);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FirePrimary();
        }
    }

    protected virtual void FixedUpdate()
    {
        velocity += targetVelocity * Time.fixedTime;
        
        if (Mathf.Abs(targetVelocity.x) == 0f)
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, Time.deltaTime * dragMultiplier.x);
        }
        if (Mathf.Abs(targetVelocity.y) == 0f)
        {
            velocity.y = Mathf.Lerp(velocity.y, 0f, Time.deltaTime * dragMultiplier.y);
        }

        velocity.x = Mathf.Clamp(velocity.x, -maxVelocity.x, maxVelocity.x);
        velocity.y = Mathf.Clamp(velocity.y, -maxVelocity.y, maxVelocity.y);

        rb.velocity = velocity;
    }

    protected virtual void FirePrimary()
    {
        //TODO: If we have pickup weapons, fire them first
        baseWeapon.Fire(this, Vector3.up, rb.velocity.y);
    }
}
