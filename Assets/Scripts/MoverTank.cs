using UnityEngine;

public class MoverTank : Mover
{
	private Pawn pawn;
	public void Start()
	{
		pawn = GetComponent<Pawn>();
	}
	
	public override void Move(Vector2 moveDirection)
	{
		Vector3 moveVector = new Vector3(moveDirection.x,0,moveDirection.y);
		moveVector = transform.TransformDirection(moveVector);
		transform.position += moveVector*(pawn.moveSpeed*Time.deltaTime);
	}

	public override void Rotate(Vector2 rotateDirection)
	{
		transform.Rotate(0,rotateDirection.x*(pawn.turnSpeed* Time.deltaTime),0);
	}


	public override void RotateTowards(Vector3 position, float turnSpead)
	{
	   Vector3 vectorToTarget = position - transform.position;
	   Quaternion lookRotation = Quaternion.LookRotation(vectorToTarget);
	   transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, pawn.turnSpeed * Time.deltaTime);
	}
}
