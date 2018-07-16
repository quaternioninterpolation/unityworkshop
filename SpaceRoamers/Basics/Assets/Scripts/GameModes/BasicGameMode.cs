using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasicGameMode : GameModeBase<BasicGameMode>
{
    public FinishLevelArea finishLevelArea;
    public SpawnPosition spawnPosition;
    public string nextLevelName;
    public int score;

    public Transform playerPrefab;

    protected PlayerEntity player;

    protected override void Awake()
    {
        base.Awake();

        finishLevelArea.SetCallback((entity) => OnLevelFinished());
    }

    public override void Reset()
    {
        base.Reset();
    }

    protected virtual void OnLevelFinished()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    public void RespawnPlayer()
    {
        if (player == null)
        {
            //
        }
    }
}
