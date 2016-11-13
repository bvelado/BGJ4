using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowIndicator : MonoBehaviour {

    GameObject Indicator;

	// Use this for initialization
	void Start ()
    {
	
	}

    void LateUpdate()
    {
        if (Indicator == null)
        {
            Indicator = GameObject.Find("Indicator");
            return;
        }
        if (Indicator.activeSelf && this.transform.parent != Indicator.transform)
        {
            this.transform.SetParent(Indicator.transform, false);
            transform.localPosition = new Vector3(24, -5, 0);
            transform.GetComponent<RectTransform>().rotation.SetEulerAngles(new Vector3(0, 0, -Indicator.GetComponent<RectTransform>().rotation.eulerAngles.z));
            Indicator.GetComponent<Image>().preserveAspect = true;
        }
        else if (Indicator.transform == transform.parent)
        {
            GetComponent<Image>().color = Indicator.GetComponent<Image>().color;
        }

    }
}
