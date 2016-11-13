using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour {

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
    }

    [SerializeField]
    private SpotPhotoTrigger currentSpotPhoto;

    public void Respawn(IRespawnable target)
    {
        if (target.GetGameObject().CompareTag("Goblin"))
        {
            target.Respawn(currentSpotPhoto.GoblinRespawnPoint.position);
        }
        else
        {
            target.Respawn(currentSpotPhoto.OrcRespawnPoint.position);
        }
    }

    public void SetCurrentSpot(SpotPhotoTrigger spot)
    {
        currentSpotPhoto = spot;
    }
}
