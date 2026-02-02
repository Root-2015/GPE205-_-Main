using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject playerOnePrefab;
	public GameObject playerPawnPrefab;

	
	public List<Controller> players;
	public List<Pawn> tanks;
	void Awake()
	{
	//Creates singletines
	if(instance == null)
		{
		instance = this;
		DontDestroyOnLoad(gameObject);
		}
	else
		{
		Destroy(gameObject);
		}
	
	//Makes the Lists work
	tanks = new List<Pawn>();
	players = new List<Controller>();
	}

	public void Start()
	{
		StartGame();

	}
	
	public void StartGame()
	{
		//Everything Needed to start the game
		//Spawn a tank
		Pawn tempTankPawn = SpawnTank(playerPawnPrefab);
		//Spawns the playercontroller
		Controller tempPlayerController = SpawnController(playerOnePrefab);
		//Makes them possess each other
		tempPlayerController.Possess(tempTankPawn);
	}
	

	public Pawn SpawnTank(GameObject prefab)
	{
		GameObject tempTankObject = Instantiate<GameObject>(playerPawnPrefab, Vector3.zero, Quaternion.identity);
		return tempTankObject.GetComponent<Pawn>();
	}


	public Controller SpawnController(GameObject prefab)
	{
		GameObject tempController = Instantiate<GameObject>(playerOnePrefab, Vector3.zero, Quaternion.identity);
		return tempController.GetComponent<Controller>();
	}

}
