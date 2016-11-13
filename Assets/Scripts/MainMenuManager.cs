using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Selectable firstSelected;
    
    void Start()
    {
        firstSelected.Select();
    }
}
