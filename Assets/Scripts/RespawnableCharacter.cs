using UnityEngine;
using System.Collections;
using System;

public class RespawnableCharacter : MonoBehaviour, IRespawnable
{
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Respawn(Vector3 position)
    {
        transform.position = position;
    }
}
