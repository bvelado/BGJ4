using UnityEngine;
using System.Collections;

public class GoblinPlus : MonoBehaviour {

	Vector3 respawnPoint;

	// Use this for initialization
	void Start () {
		SetNewCheckpoint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNewCheckpoint (){
		respawnPoint = transform.position;
	}

	public void Respawn (){
		transform.position = respawnPoint;
	}
}
