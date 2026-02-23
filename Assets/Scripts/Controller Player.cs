using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
	public InputActionAsset inputActions;


	public override void MakeDecisions()
	{
	Vector2 movementVector = inputActions["Move"].ReadValue<Vector2>();
	pawn.Move(new Vector2(0, movementVector.y));
	pawn.Rotate(new Vector2(movementVector.x,0));
	if (inputActions["Shoot"].triggered){pawn.Shoot();}
	}

	public void Update()
	{
		MakeDecisions();
	}

	public override void Start()
	{
	GameManager.instance.players.Add(this);
	
	base.Start();
	}

	public override void OnDestroy()
	{
	GameManager.instance.players.Remove(this);
	Destroy(gameObject);
	}
}
