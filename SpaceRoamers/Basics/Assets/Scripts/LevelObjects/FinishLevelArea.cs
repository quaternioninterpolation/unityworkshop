using UnityEngine;
using System.Collections;

public class FinishLevelArea : MonoBehaviour
{
    public delegate void OnPlayerEnteredFinishArea(PlayerEntity entity);

    protected OnPlayerEnteredFinishArea playerFinishedCallback;

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
}
