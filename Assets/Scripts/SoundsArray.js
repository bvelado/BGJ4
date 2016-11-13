#pragma strict

var buttonHit : String;
var soundsPlayed : AudioClip[];
private var audioGob : AudioSource;
private var isPlaying : boolean = false;

function Start () {
	audioGob = GetComponent.<AudioSource>();
}

function Update () {
	if (Input.GetButtonDown(buttonHit) && !isPlaying){
		PlaySound();
	}
}

function PlaySound (){
	isPlaying = true;
	audioGob.clip = soundsPlayed[Random.Range(0, soundsPlayed.Length - 1)];
	audioGob.Play();
	yield WaitForSeconds(1.5);
	isPlaying = false;
}