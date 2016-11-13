using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour {

    public RespawnPoints FirstRespawnPoints;

    private static RespawnManager instance;
    public static RespawnManager Instance
    {
        get { return instance; }
    }

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        currentRespawnPoints = FirstRespawnPoints;
    }

    [SerializeField]
    private RespawnPoints currentRespawnPoints;

    public void Respawn(IRespawnable target)
    {
        if (target.GetGameObject().CompareTag("Goblin"))
        {
            target.Respawn(currentRespawnPoints.GoblinRespawnPoint.position);
        }
        else
        {
            target.Respawn(currentRespawnPoints.OrcRespawnPoint.position);
        }
    }

    public void SetCurrentSpot(RespawnPoints points)
    {
        currentRespawnPoints = points;
    }
}
