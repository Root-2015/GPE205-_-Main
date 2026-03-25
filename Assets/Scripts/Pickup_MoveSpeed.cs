using UnityEngine;

public class Pickup_MoveSpeed : Pickup
{
public Powerup_MoveSpeed powerup;


public override void OnTriggerEnter(Collider other)
	{
	PowerupManager otherManager = other.GetComponent<PowerupManager>();
		if (otherManager != null)
		{
		otherManager.Add(powerup);
		Destroy(gameObject);	
		}
	}

}