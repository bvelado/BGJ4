using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Selectable firstSelected;

    [SerializeField]
    private Selectable creditsFirstSelected;

    public CanvasGroup creditsPanel;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstSelected.Select();
    }

    public void DisplayCredits(bool display)
    {
        if (display) {
            creditsPanel.DOFade(1f, 0.6f);
            creditsPanel.blocksRaycasts = true;
            creditsFirstSelected.Select();
        } else
        {
            firstSelected.Select();
            creditsPanel.DOFade(0f, 0.6f);
            creditsPanel.blocksRaycasts = false;
        }
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
