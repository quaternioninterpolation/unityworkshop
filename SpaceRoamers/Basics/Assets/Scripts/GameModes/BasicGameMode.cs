using UnityEngine;
using System.Collections;

public class BasicGameMode : GameModeBase<BasicGameMode>
{
    public FinishLevelArea finishLevelArea;
    public SpawnPosition spawnPosition;
    public int score;

    public Transform playerPrefab;

    protected PlayerEntity player;

    public override void Reset()
    {
        base.Reset();
    }

    public void RespawnPlayer()
    {
        if (player == null)
        {
            //
        }
    }
}
