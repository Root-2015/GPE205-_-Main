using UnityEngine;

public class Pickup_Health : Pickup
{
public Powerup_HealthPack powerup;


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