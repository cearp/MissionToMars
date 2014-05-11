using UnityEngine;
using System.Collections;

public class build : MonoBehaviour {
	//When the player goes to the build screen
	//disable movement
	//turn off the HUD
	void OnMouseDown(){

		GameObject gameController = GameObject.Find ("Game_Controller");
		gameController.GetComponent<game_controller> ().movement = false;
		gameController.GetComponent<game_controller> ().isHud = false;
		gameController.GetComponent<game_controller> ().cameraWasHere = Camera.main.transform.position;
		gameController.GetComponent<game_controller> ().camRot = Camera.main.transform.rotation;

		Camera.main.transform.position = new Vector3(500, 108, 100);
		Camera.main.transform.rotation = new Quaternion (00,-100,100,00);
	}
}
