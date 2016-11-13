using UnityEngine;
using System.Collections;

public class combienonsaute : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("P2_Jump"))
        {
            print(transform.position);
        }
    }
}
