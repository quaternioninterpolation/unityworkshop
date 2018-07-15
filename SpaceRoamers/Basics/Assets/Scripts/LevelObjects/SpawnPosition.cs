using UnityEngine;
using System.Collections;

public class SpawnPosition : MonoBehaviour
{
    public virtual void Respawn(PlayerEntity entity)
    {
        entity.transform.position = transform.position;
        //Give entity full health
        entity.OnRespawn();
    }
}
