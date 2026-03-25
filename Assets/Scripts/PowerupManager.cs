using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
	public List<Powerup> powerups;
	private Pawn pawn;

	public void Start()
	{
	pawn = GetComponent<Pawn>();

	powerups = new List <Powerup>();
	}

	public void Update()
	{
	UpdatePowerupLifespands();
	CheckForExpirationPowerups();
	}


	public void UpdatePowerupLifespands()
	{
		if (powerups != null){
			foreach(Powerup powerup in powerups)
			{
			powerup.lifeSpan -= Time.deltaTime;
			}
		}
	}


	public void CheckForExpirationPowerups()
	{
	List<Powerup> powerupsToDestroy = new List<Powerup>();	
	
	if (powerups != null){
		foreach(Powerup powerup in powerups)
			{
			if (powerup.lifeSpan <= 0)
				{
				powerupsToDestroy.Add(powerup);
				}
			}
	}
	if (powerupsToDestroy != null){
	foreach(Powerup powerup in powerupsToDestroy)
		{
		Remove(powerup);
		}
	}
	}


	public void Add(Powerup powerup)
	{
	powerup.Apply(pawn);
	if (powerup.lifeSpan >= 0)
		{
		powerups.Add(powerup);
		}	
	}
	public void Remove(Powerup powerup)
	{
	powerup.Remove(pawn);
	powerups.Remove(powerup);
	}

}
