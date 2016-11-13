using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OrcController : MonoBehaviour {

    public Camera Cam;
    public bool canTakeShot = false;
    public GameObject OrcHands;
    public Canvas canvas;
    public bool waitingForShot = false;
    private string currentScreenName = "first";
    private List<string> takenShots = new List<string>();

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (waitingForShot)
        {
            RaycastHit hit;
            Debug.DrawRay(Cam.transform.position, Cam.transform.forward * 100, Color.white, 0.1f);
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, 1 << LayerMask.NameToLayer("screenShotLayer")))
            {
                if (hit.transform != null && !canTakeShot)
                {
                    canTakeShot = true;
                }
            }
            else
            {
                canTakeShot = false;
            }
            if (canTakeShot)
            {
                if (Input.GetButtonDown("ScreenShot") && !takenShots.Contains(currentScreenName))
                {
                    Debug.Log(Application.persistentDataPath + "/" + currentScreenName + ".png");
                    canvas.enabled = false;
                    OrcHands.SetActive(false);
                    Application.CaptureScreenshot(Application.persistentDataPath + "/" + currentScreenName + ".png");
                    canvas.enabled = true;
                    OrcHands.SetActive(true);
                    canTakeShot = false;
                    waitingForShot = false;
                }
            }
        }
	}

    public void WaitForShot(string screenName)
    {
        if (!takenShots.Contains(screenName))
        {
            waitingForShot = true;
            currentScreenName = screenName;
        }
    }

    public void NotWaitForShot()
    {
        waitingForShot = false;
    }
}
