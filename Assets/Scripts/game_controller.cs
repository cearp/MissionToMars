using UnityEngine;
using System.Collections;
using System;


public class game_controller : MonoBehaviour {
	
	//Functionallity Bools
	public bool movement;
	public bool isHud;
	public bool overCrowd;

	//Camera Locations
	public Vector3 cameraWasHere;	//Keeps track of the cameras location before it is teleported to a menu
	public Quaternion camRot;		//Keeps track of the cameras rotation before it is teleported to a menu
	
	//Timers
	public int startTime;		//Keeps track of how long the game has been running
	public int updateTime;		//Updates resources
	public int disasterTime;	//Causes disasters
	public int expeditionDisplayTimer;
	public int collectTimer;	//Decreases resources
	
	//Resources
	public int atmosphere;
	public int population;
	public int ore;
	public int food;
	public int water;
	
	public int maxPopulation;

	//Items
	public int farms;
	public int greenhouses;
	public int icemines;
	public int mines;
	public int barracks;
	public int explorebases;
	public int mirrorsatellites;
	public int researchcenters;
	
	//Growth Rates
	public float atmosphereGrow;
	public float populationGrow;
	public float oreGrow;
	public float foodGrow;
	public float waterGrow;
	
	//Setup Variables
	public int disasterRate;	//Minimum time between disasters in minuites
	public int gatherRate;		//The time between resource incomes
	public bool turboMode;		//If enabled doubles clock speed (intended for testing)
	public float expeditionSuccessRate;
	GameObject disasterText;
	GameObject expeditionText;
	
	//Sets up most of the games variables
	void Start () {
		movement = true;
		isHud = true;
		turboMode = false;
		disasterText = GameObject.Find("disasterText");
		disasterText.guiText.text = " ";
		expeditionText = GameObject.Find("expeditionText");
		expeditionText.guiText.text = " ";

		
		//Initializing starting values
		startTime = 0;
		updateTime = 0;
		disasterTime = 0;
		expeditionDisplayTimer = -1;
		collectTimer = 0;
		atmosphere = 0;
		population = 10;
		ore = 0;
		food = 0;
		water = 0;
		maxPopulation = 50;
		expeditionSuccessRate = 0.5f;
		
		//Initializing Increase Rates
		atmosphereGrow = 1f;
		populationGrow = 0f;
		oreGrow = 0f;
		foodGrow = 0f;
		waterGrow = 0f;
		gatherRate = 2;
		disasterRate = 120;
		
		//The function responsible for managing the timers
		InvokeRepeating ("tick", 1.0f, 1.0f);



		
	}

	void getCarry(){
		GameObject carry = GameObject.Find("data_carry");
		population = carry.GetComponent<dataCarry>().population;
		food = carry.GetComponent<dataCarry>().food;
		water = carry.GetComponent<dataCarry>().water;
		farms = carry.GetComponent<dataCarry>().farms;
		greenhouses = carry.GetComponent<dataCarry>().greenhouses;
		icemines = carry.GetComponent<dataCarry>().icemines;
		mines = carry.GetComponent<dataCarry>().mines;
		barracks = carry.GetComponent<dataCarry>().barracks;
		explorebases = carry.GetComponent<dataCarry>().explorebases;
		mirrorsatellites = carry.GetComponent<dataCarry>().mirrorsatellites;
		researchcenters = carry.GetComponent<dataCarry>().researchcenters;
		
	}
	
	void Update () {

		//Checking for End Conditions
		if (atmosphere >= 1000)
			youWin ();
		if (population <= 0)
			gameOver ();
		//Checks for overcrowding
		if(population >  maxPopulation)
			overCrowd = true;
		else{overCrowd = false;}
		
		//Removes DisasterText from the screen after a certain amount of time has passed
		if (disasterText.guiText.text != " " && disasterTime > 10) 
			disasterText.guiText.text = " ";

		//Removes ExpeditionText from the screen after a certain amount of time has passed
		if (expeditionText.guiText.text != " " && expeditionDisplayTimer > 5) {
			expeditionText.guiText.text = " ";
			expeditionDisplayTimer = -1;
		}
		
		
		//Updates resources
		if(updateTime >= gatherRate){
			updateTime = 0;
			populationGrow = (int)population / 10;
			atmosphere += (int)atmosphereGrow;
			population += (int)populationGrow;
			ore += (int)oreGrow;
			
			//Accounts for overcrowding
			if(overCrowd){
				food += (int)(foodGrow / 3);
				water += (int)(waterGrow / 3);
			}
			else{
				food += (int)foodGrow;
				water += (int)waterGrow;
			}
			
			//Checks f a disaster will occur
			if (disasterTime >= disasterRate) {
				int randNum = UnityEngine.Random.Range (0,50);
				if(randNum == 8){
					disasterStrikes();
					disasterTime = 0;
				}
			}
		}
		
		//Collects Upkeep resources
		if(collectTimer >= 60){
			collectTimer = 0;
			food -= population;
			water -= population;
			if(food < 0){
				population += food;
				food = 0;
			}
			if(water < 0){
				population += water;
				water = 0;
			}
		}
		
		
	}
	//Determines and executes a disaster
	void disasterStrikes(){
		//Creating the splash screen
		Vector3 diasterText_loc = new Vector3 (0.5f, 0f, 0.5f);
		
		
		//Determining which disaster will occur
		int randNum = UnityEngine.Random.Range (0,4);
		switch (randNum) {
		case 0://Comet Strikes - Destroy all buildings in area around random point
			disasterText.guiText.text = "You're Lucky we haven't implemented this one yet";
			break;
		case 1://Famine - Lose Half Food (Rounded Up)
			food = food / 2;
			disasterText.guiText.text = "Oh Man!\n A Famine!";
			break;
		case 2://Drought - Lose Half Water (Rounded Up)
			water = water / 2;
			disasterText.guiText.text = "Look out!\n A Drought";
			break;
		case 3://Fire - Lose 1/3 Atmosphere (Rounded Up)
			atmosphere -= atmosphere/3;
			disasterText.guiText.text = "Some men just like to watch the world burn";
			break;
		case 4://Plauge - Lose 2/3 Population (Only occurs if the player is incredibly unlucky)
			disasterText.guiText.text = "Dude, you are so unlucky\nthat's a plague";
			randNum = UnityEngine.Random.Range (0,20);
			if(randNum == 0)
				population -= 2*population/3;
			break;
		default:
			break;
			
		}
		Instantiate (disasterText, diasterText_loc, Quaternion.identity);
	}
	
	//This is what happens when you lose
	void gameOver(){
		movement = false;
		isHud = false;
		Camera.main.transform.position = new Vector3(500, 105, 500);
		Camera.main.transform.rotation = new Quaternion (00,-100,100,00);
		
	}
	//This is what happens when you win
	void youWin(){
		//That's right! nothing happens when you win
	}
	
	//Handles the timers
	void tick(){
		startTime++;
		updateTime++;
		disasterTime++;
		if(expeditionDisplayTimer >= 0) //If expedition text is turned on
			expeditionDisplayTimer++;
		collectTimer++;
		//Turbo mode
		if(turboMode){
			startTime++;
			updateTime++;
			disasterTime++;
			expeditionDisplayTimer++;
			collectTimer++;
		}
	}
}
