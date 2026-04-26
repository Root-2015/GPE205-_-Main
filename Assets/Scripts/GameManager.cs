using UnityEngine;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject playerOnePrefab;
    public GameObject pawnTwoPrefab;
    public GameObject pawnOnePrefab;
    public GameObject playerPawnPrefab;
    private MapGenerator generator;
    public SettingsUI SettingsManager;

    public List<Controller> players;
	public List<Pawn> tanks;
	void Awake()
	{
		//Creates singletines
		if (instance == null)
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
		generator = GetComponent<MapGenerator>();
	}

	public void StartGame()
	{
		generator.InitializeRandom();
		generator.GenerateMap();
		//Everything Needed to start the game

		if (SettingsManager.IsMultiplayerOn == 1)
		{
            Pawn tempTankPawn = SpawnTank(pawnOnePrefab);
            //Spawns the playercontroller
            Controller tempPlayerController = SpawnController(playerOnePrefab);
            //Makes them possess each other
            tempPlayerController.Possess(tempTankPawn);


            Pawn tempTankPawn2 = SpawnTank2(pawnTwoPrefab);
			//Spawns the playercontroller
			Controller tempPlayerController2 = SpawnController(playerOnePrefab);
			//Makes them possess each other
			tempPlayerController2.Possess(tempTankPawn2);
		}
		else 
		{
            //Spawn a tank
            Pawn tempTankPawn = SpawnTank(playerPawnPrefab);
            //Spawns the playercontroller
            Controller tempPlayerController = SpawnController(playerOnePrefab);
            //Makes them possess each other
            tempPlayerController.Possess(tempTankPawn);
        }

    }


	public Pawn SpawnTank(GameObject prefab)
	{
		GameObject tempTankObject = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
		return tempTankObject.GetComponent<Pawn>();
	}

    public Pawn SpawnTank2(GameObject prefab)
    {
        GameObject tempTankObject = Instantiate<GameObject>(prefab, new Vector3(0,0,5), Quaternion.identity);
        return tempTankObject.GetComponent<Pawn>();
    }


    public Controller SpawnController(GameObject prefab)
	{
		GameObject tempController = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
		return tempController.GetComponent<Controller>();
	}

	public void DestroyAllObjects()
	{
        NotIndestructable[] components = Object.FindObjectsOfType<NotIndestructable>();
		foreach (NotIndestructable comp in components)
		{
			if (comp != null && comp.gameObject != null)
			{
				Object.Destroy(comp.gameObject);
			}
		}
	}
}

