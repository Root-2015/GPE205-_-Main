using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
	public InputActionAsset inputActions;
	public UIManager uiManager;
	public GameManager manager;

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
        manager = FindObjectOfType<GameManager>();
		GameManager.instance.players.Add(this);
        uiManager = GameObject.Find("All Managers").GetComponent<UIManager>();
        base.Start();
    }

	public override void OnDestroy()
	{
		GameManager.instance.players.Remove(this);
		uiManager.ActivateGameOver();
        manager.DestroyAllObjects();
		Destroy(gameObject);
	}
}
