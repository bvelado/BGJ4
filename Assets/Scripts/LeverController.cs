using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LeverController : MonoBehaviour
{
    public GameObject activable;
    public float time = 3f;
    public bool isTimed = false;
    private float timer = 0f;
    private bool state = false;
    private bool triggered = false;

    void Update()
    {
        if (triggered)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!state)
                {
                    activable.GetComponent<Animator>().SetTrigger("Open");
                    state = true;
                }
            }
        }
        if (state && isTimed)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                timer = 0;
                activable.GetComponent<Animator>().SetTrigger("Close");
                state = false;
            }
        }
    }



    void OnTriggerExit(Collider other)
    {
        triggered = false;
    }

    void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }
}
