using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

/// <summary>
/// Un truc qui peut prendre la pose pour une photo
/// </summary>
public interface IPosable
{
    void DisplayCanShoot(SpotPhotoTrigger spotPhoto);
    void HideCanShoot();
    void Pose(SpotPhotoTrigger spotPhoto);
    void Unpose();
    bool IsPosing();
}

public class Posable : MonoBehaviour, IPosable {

    Animator m_animator;
    public Text Message;

    private bool isPosing = false;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void DisplayCanShoot(SpotPhotoTrigger spotPhoto)
    {
        Message.text = spotPhoto.TextCanShoot;
    }

    public void HideCanShoot()
    {
        Message.text = "";
        m_animator.SetTrigger("CancelPose");
    }

    public virtual void Pose(SpotPhotoTrigger spotPhoto)
    {
        isPosing = true;
        Message.text = spotPhoto.TextShot;
        m_animator.ResetTrigger("CancelPose");
        m_animator.SetTrigger(spotPhoto.Title);
    }

    public bool IsPosing()
    {
        return isPosing;
    }

    public void Unpose()
    {
        isPosing = false;
        m_animator.SetTrigger("CancelPose");
    }
}
