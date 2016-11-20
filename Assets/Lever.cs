using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Lever : MonoBehaviour, IUsable
{
    private Animator m_animator;

    [SerializeField]
    private Text m_message;

    [SerializeField]
    [Tooltip("Seulement des IActivables dedans!")]
    private GameObject[] activables;

    bool inRange;
    bool hasBeenUsed = false;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void Use()
    {
        m_animator.SetTrigger("Activate");
        foreach(var activable in activables)
        {
            if (activable.GetComponent<IActivable>() != null)
                activable.GetComponent<IActivable>().Activate();
        }
    }

    void Update()
    {
        if (inRange && Input.GetButtonDown("P2_Use"))
        {
            Use();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Goblin"))
        {
            inRange = true;
            m_message.text = "Kein - Press B to use";
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Goblin"))
        {
            inRange = false;
            m_message.text = "";
        }
    }
}
