using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider){
		if (collider.CompareTag("Player")){
			//collider.GetComponent<GoblinController>().Respawn();
		}
	}
}
