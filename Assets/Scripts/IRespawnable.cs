using UnityEngine;
using System.Collections;

public interface IRespawnable {
    void Respawn(Vector3 position);
    GameObject GetGameObject();
}
