using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    public bool followX;
    public bool followY;
    public Vector2 followOffset = new Vector2(0f, -50f);

    public float smoothTime = 0.3f;
    public float maxSpeed = 20f;

    protected Vector2 velocity;
    
    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {
            Vector2 offsetTarget = new Vector2(followTarget.transform.position.x, followTarget.transform.position.y) - followOffset;
            Vector2 movePos = Vector2.SmoothDamp(transform.position, offsetTarget, ref velocity, smoothTime, maxSpeed, Time.deltaTime);
            if (!followX) movePos.x = transform.position.x;
            if (!followY) movePos.y = transform.position.y;

            transform.position = new Vector3(movePos.x, movePos.y, transform.position.z);
        }
    }

    public void SetTarget(Transform target)
    {
        this.followTarget = target;
    }
}
