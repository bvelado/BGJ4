using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider){
		if (collider.CompareTag("Player")){
			//collider.GetComponent<GoblinController>().SetNewCheckpoint();
		}
	}
}
