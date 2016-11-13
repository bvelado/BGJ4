using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]
public class DeathTriggerNigga : MonoBehaviour {
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<IRespawnable>() != null)
        {
            RespawnManager.Instance.Respawn(col.GetComponent<IRespawnable>());
        }
    }

}
