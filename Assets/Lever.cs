using UnityEngine;
using System.Collections;
using System;

public class Lever : MonoBehaviour, IUsable
{
    private Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void Use()
    {
        m_animator.SetTrigger("Activate");
    }
}
