using UnityEngine;
using System.Collections.Generic;
using System;

public enum RandomType {Random, Seeded, MapOfTheDay}

public class MapGenerator : MonoBehaviour
{
	[Header("Randomness Data")]
	public RandomType randomType;
	public int seed;

	[Header("TileData")]
	public List<Tile> availableTiles;
	public float  tileWidth;
	public float tileLength;
	public int mapCol;
	public int mapRow;
	public Tile[,] grid;

	public void randomTypeRandom() 
	{
        randomType = RandomType.Random;
    }

    public void randomTypeSeeded()
    {
        randomType = RandomType.Seeded;
    }
    
	public void randomTypeMapOfTheDay()
    {
        randomType = RandomType.MapOfTheDay;
    }

	public void SetSeed(int ChosenSeed) 
	{
		seed = ChosenSeed;
    }

    public void InitializeRandom()
	{
		if (randomType == RandomType.Seeded)
		{
			UnityEngine.Random.InitState(seed);
		}
		else if (randomType == RandomType.Random)
		{
			UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
		}
		else if (randomType == RandomType.MapOfTheDay)
		{
			UnityEngine.Random.InitState(DateToInt(DateTime.Now.Date));
		}
	}


	public int DateToInt(DateTime date)
	{
	return date.Year + date.Month + date.Day;
	}


	public void GenerateMap()
	{
	grid = new Tile[mapRow, mapCol];
	for (int currentRow = 0; currentRow < mapRow; currentRow++)
		{
		for (int currentCol = 0; currentCol < mapCol; currentCol++)
			{
			Tile temptile = Instantiate<Tile>(GetRandomTile()) as Tile;
			Vector3 correctPosition = Vector3.zero;
			correctPosition.x = currentRow * tileWidth;
			correctPosition.z = currentCol * tileLength;
			temptile.transform.position = correctPosition;

			if(currentRow > 0)
			{
			temptile.doorWest.SetActive(false);
			}
			if (currentRow < mapRow-1)
			{
			temptile.doorEast.SetActive(false);
			}
			if(currentCol > 0)
			{
			temptile.doorSouth.SetActive(false);
			}
			if (currentCol < mapCol-1)
			{
			temptile.doorNorth.SetActive(false);
			}
			
			grid[currentRow, currentCol] = temptile;
			}
		}	




	}

	public Tile GetRandomTile()
	{
	int tileNumber = UnityEngine.Random.Range(0, availableTiles.Count);
	return availableTiles[tileNumber];
	}
}
