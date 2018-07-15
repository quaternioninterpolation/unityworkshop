using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : BaseEntity
{
    public float maxVelocity = 5f;
    public float accelerationX = 10f;
    public float accelerationY = 2f;
    public float idleDrag = 15f;
    public Weapon baseWeapon;

    protected Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        team = 1;
    }

    /// <summary>
    /// Updates at a regular interval before physics is calculated
    /// </summary>
    protected void FixedUpdate()
    {
        Vector2 movement = new Vector2();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector2.left * accelerationX;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector2.right * accelerationX;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector2.up * accelerationY;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector2.down * accelerationY;
        }

        //Limit our velocity to maximum
        if (movement.sqrMagnitude > 0f)
        {
            rb.AddForce(movement * Time.deltaTime);
            if (rb.velocity.sqrMagnitude > maxVelocity * maxVelocity)
            {
                rb.velocity = rb.velocity.normalized * maxVelocity;
            }
        }
        else
        {
            //Add drag
            //Drag = velocity - idleDrag * deltaTime
            float velocityMag = rb.velocity.magnitude;
            if (velocityMag > 0f)
            {
                velocityMag = Mathf.Max(velocityMag - idleDrag * Time.deltaTime, 0f);
                rb.velocity = rb.velocity.normalized * velocityMag;
            }
        }

    }

    /// <summary>
    /// Updates every frame
    /// </summary>
    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FirePrimary();
        }
    }

    protected virtual void FirePrimary()
    {
        //TODO: If we have pickup weapons, fire them first
        baseWeapon.Fire(this, transform.position, Vector3.up);
    }
}
