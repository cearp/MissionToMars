using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	GameObject dataCarry;
	GameObject weightTxt;
	public int id;
	public bool selected;
	public GameObject[] buttons = new GameObject[14];

	void Start () {

		Invoke ("startDelay", 0.1f);

		//for (int i = 0; i < 14; i++) 
			//buttons[i].renderer.material.color = Color.gray;
	}

	void startDelay(){
		id++;
		selected = false;
		dataCarry = GameObject.Find ("data_carry");
		weightTxt = GameObject.Find ("weightText");
		buttons [0] = GameObject.Find ("B_Add");
		buttons [1] = GameObject.Find ("B_Farm");
		buttons [2] = GameObject.Find ("B_Food");
		buttons [3] = GameObject.Find ("B_Greenhouse");
		buttons [4] = GameObject.Find ("B_Icedrill");
		buttons [5] = GameObject.Find ("B_Mirrorsatellite");
		buttons [6] = GameObject.Find ("B_Oredrill");
		buttons [7] = GameObject.Find ("B_People");
		buttons [8] = GameObject.Find ("B_Researchcenter");
		buttons [9] = GameObject.Find ("B_Reset");
		buttons [10] = GameObject.Find ("B_Send");
		buttons [11] = GameObject.Find ("B_Settlement");
		buttons [12] = GameObject.Find ("B_Sub");
		buttons [13] = GameObject.Find ("B_Water");
	}

	//This script is unfinished, for now it will only start the game.
	//Eventually it will selet button boxes and change variables
	void OnMouseDown(){
		switch (id) {
		case 1:
			b_add ();
			break;
		case 2:
			b_farm ();
			break;
		case 3:
			b_food ();
			break;
		case 4:
			b_greenhouse ();
			break;
		case 5:
			b_icedrill ();
			break;
		case 6:
			b_mirrorsatelite();
			break;
		case 7:
			b_oredrill();
			break;;
		case 8:
			b_people ();
			break;
		case 9:
			b_researchcenter();
			break;
		case 10:
			b_reset();
			break;
		case 11:
			b_send();
			break;
		case 12:
			b_settlement();
			break;
		case 13:
			b_subtract();
			break;
		case 14:
			b_water();
			break;
		default:
			GameObject diasterTEXT = GameObject.Find("disasterText");
			diasterTEXT.guiText.text = "You did something wrong to the menu\n:(\nYou Suck";
			break;

		}
	}


	void b_add(){
		//setGreen ();
		GameObject temp = buttons[0];
		string tmpStr = "";
		for (int i = 0; i < 14; i++){
			if(buttons[i].GetComponent<Menu>().selected)
				temp = buttons[i];			
		}

		switch(temp.GetComponent<Menu>().id){
			case 2:
				dataCarry.GetComponent<dataCarry>().farms++;
				break;
			case 3:
				if(dataCarry.GetComponent<dataCarry>().weight < 20){
					dataCarry.GetComponent<dataCarry>().food += 15;
					dataCarry.GetComponent<dataCarry>().weight++;
					tmpStr = "Weight: " + dataCarry.GetComponent<dataCarry>().weight.ToString()+" / 20";
					weightTxt.guiText.text = tmpStr;
				}
				break;
			case 4:
				dataCarry.GetComponent<dataCarry>().greenhouses++;
				break;
			case 5:
				dataCarry.GetComponent<dataCarry>().icemines++;
				break;
			case 6:
				dataCarry.GetComponent<dataCarry>().mirrorsatellites++;
				break;
			case 7:
				dataCarry.GetComponent<dataCarry>().mines++;
				break;
			case 8:
				if(dataCarry.GetComponent<dataCarry>().weight < 20){
					dataCarry.GetComponent<dataCarry>().population += 10;
					dataCarry.GetComponent<dataCarry>().weight++;
					tmpStr = "Weight: " + dataCarry.GetComponent<dataCarry>().weight.ToString()+" / 20";
					weightTxt.guiText.text = tmpStr;
				}
				break;
			case 9:
				dataCarry.GetComponent<dataCarry>().researchcenters++;
				break;
			case 12:
				GameObject disasterTEXT = GameObject.Find ("disasterText");
				disasterTEXT.guiText.text = "I don't know what this is";
				break;
			case 14:
				if(dataCarry.GetComponent<dataCarry>().weight < 20){
					dataCarry.GetComponent<dataCarry>().water += 15;
					dataCarry.GetComponent<dataCarry>().weight++;
					tmpStr = "Weight: " + dataCarry.GetComponent<dataCarry>().weight.ToString()+" / 20";
					weightTxt.guiText.text = tmpStr;
				}
				break;
			default:
				break;
		}
	}
	void b_farm(){
		setGreen ();
	}
	void b_food(){
		setGreen ();
	}
	void b_greenhouse(){
		setGreen ();
	}
	void b_icedrill(){
		setGreen ();
	}
	void b_mirrorsatelite(){
		setGreen ();
	}
	void b_oredrill(){
		setGreen ();
	}
	void b_people(){
		setGreen ();
	}
	void b_researchcenter(){
		setGreen ();
	}
	void b_reset(){
		setGreen ();
	}
	void b_send(){
		setGreen ();
		Application.LoadLevel("MainGame");
	}
	void b_settlement(){
		setGreen ();
	}
	void b_subtract(){
		string tmpStr = "";
		GameObject temp = buttons[0];
		for (int i = 0; i < 13; i++){
			if(buttons[i].GetComponent<Menu>().selected)
				temp = buttons[i];			
		}

		switch(temp.GetComponent<Menu>().id){
		case 2:
			if(dataCarry.GetComponent<dataCarry>().farms > 0)
				dataCarry.GetComponent<dataCarry>().farms--;
			break;
		case 3:
			if(dataCarry.GetComponent<dataCarry>().weight > 0){
				dataCarry.GetComponent<dataCarry>().food -= 15;
				dataCarry.GetComponent<dataCarry>().weight--;
				tmpStr = "Weight: " + dataCarry.GetComponent<dataCarry>().weight.ToString()+" / 20";
				weightTxt.guiText.text = tmpStr;
			}
			break;
		case 4:
			if(dataCarry.GetComponent<dataCarry>().greenhouses > 0)
				dataCarry.GetComponent<dataCarry>().greenhouses--;
			break;
		case 5:
			if(dataCarry.GetComponent<dataCarry>().icemines > 0)
				dataCarry.GetComponent<dataCarry>().icemines--;
			break;
		case 6:
			if(dataCarry.GetComponent<dataCarry>().mirrorsatellites > 0)
				dataCarry.GetComponent<dataCarry>().mirrorsatellites--;	
			break;
		case 7:
			if(dataCarry.GetComponent<dataCarry>().mines > 0)
				dataCarry.GetComponent<dataCarry>().mines--;
			break;
		case 8:
			if(dataCarry.GetComponent<dataCarry>().weight > 0){
				dataCarry.GetComponent<dataCarry>().population -= 10;
				dataCarry.GetComponent<dataCarry>().weight--;
				tmpStr = "Weight: " + dataCarry.GetComponent<dataCarry>().weight.ToString()+" / 20";
				weightTxt.guiText.text = tmpStr;
			}
			break;
		case 9:
			if(dataCarry.GetComponent<dataCarry>().researchcenters > 0)
				dataCarry.GetComponent<dataCarry>().researchcenters--;
			break;
		case 12:
			GameObject disasterTEXT = GameObject.Find ("disasterText");
			disasterTEXT.guiText.text = "I don't know what this is";
			break;
		case 14:
			if(dataCarry.GetComponent<dataCarry>().weight > 0){
				dataCarry.GetComponent<dataCarry>().water -= 15;
				dataCarry.GetComponent<dataCarry>().weight--;
				tmpStr = "Weight: " + dataCarry.GetComponent<dataCarry>().weight.ToString()+" / 20";
				weightTxt.guiText.text = tmpStr;
			}
			break;
		default:
			break;
		}
	}
	void b_water(){
		setGreen ();
	}




	void setGreen(){
		for (int i = 0; i < 14; i++){
			//buttons[i].renderer.material.color = Color.gray;
			buttons[i].GetComponent<Menu>().selected = false;
		}
		//renderer.material.color = Color.green;
		switch(id){
			case 1:
				break;
			case 10:
				break;
			case 13:
				break;
			default:
				selected = true;
				break;
		}
	}
}
