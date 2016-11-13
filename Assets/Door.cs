using UnityEngine;
using System.Collections;
using System;

public class Door : MonoBehaviour, IActivable {

    private Animator m_animator;

    public void Activate()
    {
        m_animator.SetTrigger("Open");
    }

    void Start () {
        m_animator = GetComponent<Animator>();
	}
}
