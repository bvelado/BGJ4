using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]
public class DeathTriggerNigga : MonoBehaviour, IRespawnable {
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Respawn(Vector3 position)
    {
        transform.position = position;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<IRespawnable>() != null)
        {
            RespawnManager.Instance.Respawn(this);
        }
    }

}
