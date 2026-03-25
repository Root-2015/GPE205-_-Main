using UnityEngine;
[System.Serializable]
public class Powerup_MoveSpeed : Powerup
{
	public float SpeedBoostAmount;



	public override void Apply(Pawn target)
	{
	target.moveSpeed += SpeedBoostAmount;
	}
   	
	public override void Remove(Pawn target)
	{
	target.moveSpeed -= SpeedBoostAmount;
	}

}
