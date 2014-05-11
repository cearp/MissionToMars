using UnityEngine;
using System.Collections;

public class buyBuilding : MonoBehaviour {
	public GameObject building;
	public int id;

	void OnMouseDown(){
		int temp = 0;
		GameObject gameController = GameObject.Find ("Game_Controller");
		switch (id) {
			case 0:
				temp = gameController.GetComponent<game_controller>().farms;
				break;
			case 1:
				temp = gameController.GetComponent<game_controller>().mines;
				break;
			case 2:
				temp = gameController.GetComponent<game_controller>().greenhouses;
				break;
			case 3:
				temp = gameController.GetComponent<game_controller>().explorebases;
				break;
			case 4:
				temp = gameController.GetComponent<game_controller>().barracks;
				break;
			case 5:
				temp = gameController.GetComponent<game_controller>().icemines;
				break;
			default:
				break;
		}
		if(temp > 0){
			Camera.main.transform.position = gameController.GetComponent<game_controller> ().cameraWasHere;
			Camera.main.transform.rotation = gameController.GetComponent<game_controller> ().camRot;
			gameController.GetComponent<game_controller> ().movement = true;
			gameController.GetComponent<game_controller> ().isHud = true;
			
			Quaternion spawnRotation = new Quaternion (0, 0, 0, 0);
			
			float x = Input.mousePosition.x;
			float y = 0.0f;
			float z = Input.mousePosition.z;
			
			Vector3 spawnPos = new Vector3 (x, y, z);
			
			Instantiate (building, spawnPos, spawnRotation);
			switch (id) {
			case 0:
				gameController.GetComponent<game_controller>().farms--;
				break;
			case 1:
				gameController.GetComponent<game_controller>().mines--;
				break;
			case 2:
				gameController.GetComponent<game_controller>().greenhouses--;
				break;
			case 3:
				gameController.GetComponent<game_controller>().explorebases--;
				break;
			case 4:
				gameController.GetComponent<game_controller>().barracks--;
				break;
			case 5:
				gameController.GetComponent<game_controller>().icemines--;
				break;
			default:
				break;
			}
		}
		
	}
	
}
