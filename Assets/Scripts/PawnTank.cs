using UnityEngine;

public class PawnTank : Pawn
{

	public override void Start()
	{
	GameManager.instance.tanks.Add(this);
	base.Start();
	}

	public override void Move(Vector3 directionToMove)
	{
		mover.Move(directionToMove);
	}

	public override void Rotate(Vector3 directionToRotate)
	{
		mover.Rotate(directionToRotate);
	}

	public override void Shoot(){}

	public void OnDestroy()
	{
	GameManager.instance.tanks.Remove(this);
	}
}
