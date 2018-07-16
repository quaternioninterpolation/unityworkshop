using UnityEngine;
using System.Collections;

public class FinishLevelArea : MonoBehaviour
{
    public delegate void OnPlayerEnteredFinishArea(PlayerEntity entity);

    protected OnPlayerEnteredFinishArea playerFinishedCallback;
    protected BoxCollider2D[] boxColliders;
    protected CircleCollider2D[] circleColliders;

    private void Awake()
    {
        boxColliders = GetComponents<BoxCollider2D>();
        circleColliders = GetComponents<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEntity player = collision.GetComponent<PlayerEntity>();
        if (player != null)
        {
            playerFinishedCallback?.Invoke(player);
        }
    }

    public void SetCallback(OnPlayerEnteredFinishArea callback)
    {
        this.playerFinishedCallback = callback;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        boxColliders = GetComponents<BoxCollider2D>();
        circleColliders = GetComponents<CircleCollider2D>();

        foreach (var col in boxColliders)
        {
            Gizmos.DrawWireCube(transform.position + col.offset.ToVector3(), col.size);
        }

        foreach (var col in circleColliders)
        {
            Gizmos.DrawWireSphere(transform.position + col.offset.ToVector3(), col.radius);
        }
    }
    #endif
}
