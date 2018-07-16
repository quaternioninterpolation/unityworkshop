using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasicGameMode : GameModeBase<BasicGameMode>
{
    public FollowCamera camera;
    public FinishLevelArea finishLevelArea;
    public SpawnPosition spawnPosition;
    public string nextLevelName;
    public int score;
    public float respawnTime = 2f;

    public Transform playerPrefab;

    protected PlayerEntity player;

    protected override void Awake()
    {
        base.Awake();

        finishLevelArea.SetCallback((entity) => OnLevelFinished());
        RespawnPlayer();
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
        StartCoroutine(RespawnCoroutine());
    }

    protected IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnTime);
        //Spawn new player
        Transform playerInstance = Instantiate(playerPrefab, spawnPosition.transform.position, Quaternion.identity);
        player = playerInstance.GetComponent<PlayerEntity>();
        player.SetDestroyCallback(RespawnPlayer);
        camera.SetTarget(playerInstance.transform);
    }
}
