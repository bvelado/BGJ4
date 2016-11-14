using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider))]
public class DeathTriggerNigga : MonoBehaviour {

    public bool killBoth = true;

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<IRespawnable>() != null)
        {
            if (killBoth)
                RespawnManager.Instance.Respawn(col.GetComponent<IRespawnable>());
            else if (col.CompareTag("Goblin"))
                RespawnManager.Instance.Respawn(col.GetComponent<IRespawnable>());
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawIcon(transform.position, "skull", true);
    }
}
