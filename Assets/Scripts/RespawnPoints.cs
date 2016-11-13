using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class RespawnPoints : MonoBehaviour {

    public Transform OrcRespawnPoint;
    public Transform GoblinRespawnPoint;

    bool hasBeenTriggered = false;

    void OnTriggerEnter(Collider col)
    {
        if(!hasBeenTriggered)
            RespawnManager.Instance.SetCurrentSpot(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(OrcRespawnPoint.position, 2.2f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GoblinRespawnPoint.position, 1.6f);
    }
}
