using UnityEngine;
using System.Collections;

public class buildMenuBack : MonoBehaviour {
	//When the back button is pressed, return the camera to its previous position
	//re-enable movement
	//turn the hud back on
	void OnMouseDown(){
		GameObject gameController = GameObject.Find ("Game_Controller");
		Camera.main.transform.position = gameController.GetComponent<game_controller> ().cameraWasHere;
		Camera.main.transform.rotation = gameController.GetComponent<game_controller> ().camRot;
		gameController.GetComponent<game_controller> ().movement = true;
		gameController.GetComponent<game_controller> ().isHud = true;

	}
}
