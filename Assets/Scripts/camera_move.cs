using UnityEngine;
using System.Collections;
/*
This script controls the camera movement

Every clock cycle it checks the mouse position, and then if the mouse is at or beyond
a certain position on the screen the camera pans in that direction

Additionally if the camera height is within certain limits the mousewheel can be used
to control the camera height
*/
public class camera_move : MonoBehaviour {
	public Vector3 cameraPos;
	public bool move;
	public GameObject gameController;

	void Start () {
		gameController = GameObject.Find ("Game_Controller");
	}
	

	void Update () {
		move = gameController.GetComponent<game_controller> ().movement;

		if(move){
			cameraPos = Camera.main.transform.position;
			//Iser is scrolling Back
			if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraPos.y < 100)
				cameraPos.y++;
			else if(Input.GetAxis ("Mouse ScrollWheel") > 0 && cameraPos.y > 10)
				cameraPos.y--;

			if(Input.mousePosition.x >= Screen.width - Screen.width * 0.05f && Camera.main.transform.position.x < 250)
				cameraPos.x++;
			else if(Input.mousePosition.x <= Screen.width * 0.05f && Camera.main.transform.position.x > -250)
				cameraPos.x--;
			if(Input.mousePosition.y >= Screen.height - Screen.height * 0.05f && Camera.main.transform.position.z < 250)
				cameraPos.z++;
			else if(Input.mousePosition.y <= Screen.height * 0.05f && Camera.main.transform.position.z > -250)
				cameraPos.z--;

			Camera.main.transform.position = cameraPos;
		}
	}
}
