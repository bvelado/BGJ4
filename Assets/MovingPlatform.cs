using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public Transform oldParent;

    void OnCollisionEnter(Collision col)
    {
        print("test");

        if(col.gameObject.CompareTag("Orc"))
        {
            oldParent = col.transform;
            col.transform.SetParent(transform, true);
        }
    }

    void OnCollisionExit(Collision col)
    {
        print("nop");

        if (col.gameObject.CompareTag("Orc"))
        {
            col.transform.SetParent(null);
        }
    }

}
