using UnityEngine;

public class PawnTank : Pawn
{
	private Shootertank shooter;
	public float shootForce;

	public override void Start()
	{
	GameManager.instance.tanks.Add(this);
	shooter = GetComponent<Shootertank>();
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

	public override void Shoot()
	{
		shooter.Shoot();
		noiceMaker.Shoot();
	}


	public override void RotateTowards (Vector3 position)
	{
	mover.RotateTowards(position, turnSpeed);
	}



	public override void OnDestroy()
	{
	controller.OnDestroy();
	GameManager.instance.tanks.Remove(this);
	Destroy(gameObject);
	}
}
