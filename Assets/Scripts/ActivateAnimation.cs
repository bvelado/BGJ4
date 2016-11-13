using UnityEngine;
using System.Collections;
using System;

public class ActivateAnimation : MonoBehaviour, IActivable {

    [SerializeField]
    private Animator m_animator;

    public string triggerName = "Activate";

    public void Activate()
    {
        m_animator.SetTrigger(triggerName);
    }
}
