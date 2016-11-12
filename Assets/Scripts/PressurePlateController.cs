using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PressurePlateController : MonoBehaviour {

    public GameObject[] activables;
    public GameObject movablesRoot;
    public float time = 3f;
    public bool isTimed = false;
    private float timer = 0f;
    private bool state = false;
    private bool triggered = false;

    void Update()
    {
        if (triggered)
        {
            if (!state)
            {
                foreach (GameObject activable in activables)
                {
                    activable.GetComponent<Animator>().SetTrigger("Open");
                }
                state = true;
            }
        }
        if (state && isTimed)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                timer = 0;
                foreach (GameObject activable in activables)
                {
                    activable.GetComponent<Animator>().SetTrigger("Close");
                }
                state = false;
            }
        }
    }



    void OnTriggerExit(Collider other)
    {
        triggered = false;
        movablesRoot.GetComponent<Animator>().SetTrigger("Close");
    }

    void OnTriggerEnter(Collider other)
    {
        triggered = true;
        movablesRoot.GetComponent<Animator>().SetTrigger("Open");
    }

    void OnTriggerStay(Collider other)
    {
        triggered = true;
        movablesRoot.GetComponent<Animator>().SetTrigger("Open");
    }
}
