using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PushOnTrigger : MonoBehaviour
{
    public float cooldown = 5f;
    public float activeTime = 2f;
    private float timer = 0f;
    private bool isPushing = false;
    private bool havePushRecently = false;

    void Update()
    {
        if (isPushing)
        {
            if (timer >= activeTime)
            {
                isPushing = false;
                this.GetComponent<Collider>().enabled = false;
                timer = 0f;
            }
        }
        else
        {
            if (timer >= cooldown)
            {
                isPushing = true;
                havePushRecently = false;
                this.GetComponent<Collider>().enabled = true;
                timer = 0f;
            }
        }
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody otherBody;

        if (!havePushRecently)
        {
            otherBody = other.gameObject.GetComponent<Rigidbody>();
            otherBody.AddExplosionForce(5000f, this.transform.position, 100f);
            havePushRecently = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }
}
