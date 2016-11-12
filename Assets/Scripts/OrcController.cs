using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OrcController : MonoBehaviour {

    public Camera Cam;
    public bool canTakeShot = false;
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
                    Application.CaptureScreenshot(Application.persistentDataPath + "/" + currentScreenName + ".png");
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
