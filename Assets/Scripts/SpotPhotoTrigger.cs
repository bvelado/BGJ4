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

    [SerializeField]
    private string title;
    public string Title { get { return title; } }

    private BoxCollider m_trigger;
    private bool hasBeenActivated = false;
    
    public OrcController Orc;

    void Awake()
    {
        m_trigger = GetComponent<BoxCollider>();
    }

    void Reset()
    {
        Orc = FindObjectOfType<OrcController>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Goblin")&& col.GetComponent<IPosable>() != null)
        {
            col.GetComponent<IPosable>().DisplayCanShoot(this);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetButtonDown("P2_Use") && col.GetComponent<IPosable>() != null)
        {
            hasBeenActivated = true;
            Orc.canTakeShot = true;
            if (!col.GetComponent<IPosable>().IsPosing())
            {
                col.GetComponent<IPosable>().Pose(this);
            }
            else
            {
                col.GetComponent<IPosable>().DisplayCanShoot(this);
                col.GetComponent<IPosable>().Unpose();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Goblin") && col.GetComponent<IPosable>() != null) {
            col.GetComponent<IPosable>().HideCanShoot();
            Orc.canTakeShot = false;
        }   
    }

    
}
