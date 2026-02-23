using UnityEngine;

public abstract class Controller : MonoBehaviour
{
	public Pawn pawn;
	
	public abstract void MakeDecisions();
	public abstract void OnDestroy();

	public void Possess(Pawn pawnToPossess) 
	{
		pawnToPossess.controller = this;
		this.pawn = pawnToPossess;
	}

	public void unpossess() 
	{
		pawn.controller = null;
		pawn = null;
	}
	public virtual void Start(){}
}
