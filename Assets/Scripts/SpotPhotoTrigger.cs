using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class SpotPhotoTrigger : MonoBehaviour {

    [SerializeField]
    private string textCanShoot;
    public string TextCanShoot { get { return textCanShoot; } }
    [SerializeField]
    private string textShot;
    public string TextShot { get { return textShot; } }

    private BoxCollider m_trigger;
    private bool hasBeenActivated = false;

    void Start()
    {
        m_trigger = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(!hasBeenActivated)
        {
            if (col.GetComponent<IPosable>() != null)
                col.GetComponent<IPosable>().DisplayCanShoot(this);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (!hasBeenActivated && Input.GetButtonDown("Fire1"))
        {
            hasBeenActivated = true;

            if (col.GetComponent<IPosable>() != null)
                col.GetComponent<IPosable>().Shoot(this);
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<IPosable>() != null) {
            col.GetComponent<IPosable>().HideCanShoot();
        }   
    }
}
