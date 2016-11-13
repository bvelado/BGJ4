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
}

public class Posable : MonoBehaviour, IPosable {

    public Text Message;

    public void DisplayCanShoot(SpotPhotoTrigger spotPhoto)
    {
        Message.text = spotPhoto.TextCanShoot;
    }

    public void HideCanShoot()
    {
        Message.text = "";
    }

    public virtual void Pose(SpotPhotoTrigger spotPhoto)
    {
        Message.text = spotPhoto.TextShot;
    }
}
