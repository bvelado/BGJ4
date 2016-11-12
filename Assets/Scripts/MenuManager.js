#pragma strict

import UnityEngine.SceneManagement;
import UnityEngine.UI;

@Tooltip ("Niveau à charger quand le joueur clique sur JOUER")
var levelToLoad : String;

var cursorsParent : Transform;
var cursorInterval : float = 0.2;
var loadingScreen : GameObject;
var loadingProgress : Image;
private var cursorIdx : int = -1;
private var canMoveCursor : boolean = true;

function Start () {
	cursorIdx = 0;
	for (var i = 0; i < cursorsParent.childCount; i++){
		cursorsParent.GetChild(i).gameObject.SetActive(false);
	}
	cursorsParent.GetChild(cursorIdx).gameObject.SetActive(true);
}

function Update () {
	if (canMoveCursor){
		if (Input.GetAxis("Vertical") > 0){
			MoveCursorUp();
		}
		if (Input.GetAxis("Vertical") < 0){
			MoveCursorDown();
		}
		if (Input.GetButtonDown("Fire1")){
			switch (cursorIdx){
				case 0:
					LoadFirstLevel();
					break;
				case cursorsParent.childCount - 1:
					ExitGame();
					break;
			}
		}
	}
}

function LoadFirstLevel (){
	DisplayLoadingScreen();
	if (loadingProgress != null){
		loadingProgress.fillAmount = SceneManager.LoadSceneAsync(levelToLoad).progress;
	}
	else {
		SceneManager.LoadScene(levelToLoad);
	}
}

function DisplaySettingsMenu (){

}

function LoadGame (){

}

function ExitGame (){
	Application.Quit();
}

function MoveCursorUp (){
	canMoveCursor = false;
	if (cursorIdx == 0){
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(false);
		cursorIdx = cursorsParent.childCount -1;
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(true);
	}
	else {
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(false);
		cursorIdx -= 1;
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(true);
	}
	yield WaitForSeconds (cursorInterval);
	canMoveCursor = true;
}

function MoveCursorDown (){
	canMoveCursor = false;
	if (cursorIdx == cursorsParent.childCount -1){
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(false);
		cursorIdx = 0;
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(true);
	}
	else {
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(false);
		cursorIdx += 1;
		cursorsParent.GetChild(cursorIdx).gameObject.SetActive(true);
	}
	yield WaitForSeconds (cursorInterval);
	canMoveCursor = true;
}

function DisplayLoadingScreen (){
	if (loadingScreen != null){
		loadingScreen.SetActive(true);
	}
}