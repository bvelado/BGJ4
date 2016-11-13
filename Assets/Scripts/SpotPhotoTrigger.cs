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

    private OrcController m_orc;

    public Transform OrcRespawnPoint;
    public Transform GoblinRespawnPoint;

    void Start()
    {
        m_trigger = GetComponent<BoxCollider>();
        m_orc = FindObjectOfType<OrcController>();
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
        if (Input.GetButtonDown("P2_Action") && col.GetComponent<IPosable>() != null)
        {
            hasBeenActivated = true;
            m_orc.canTakeShot = true;
            col.GetComponent<IPosable>().Pose(this);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Goblin") && col.GetComponent<IPosable>() != null) {
            col.GetComponent<IPosable>().HideCanShoot();
            m_orc.canTakeShot = false;
        }   
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(OrcRespawnPoint.position, 2.2f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(GoblinRespawnPoint.position, 1.6f);
    }
}
