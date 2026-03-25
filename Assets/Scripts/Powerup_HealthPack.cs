using UnityEngine;
[System.Serializable]
public class Powerup_HealthPack : Powerup
{
	public float damageHealed;	


	
	
	



public override void Apply(Pawn other)
{
	Health otherHealth = other.GetComponent<Health>();
	if (otherHealth != null)
		{
		otherHealth.heal(damageHealed);
		Debug.Log("Healed");
		}
	
}
public override void Remove(Pawn target){}



}