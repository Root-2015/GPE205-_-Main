using UnityEngine;

public class ControllerEnemyChaser : ControllerEnemiAI
{
  public override void Start()
	{
	GameManager.instance.players.Add(this);
	
	base.Start();
	}

   public void Update()
	{
		MakeDecisions();
	}




     public override void MakeDecisions()
	{
	
	switch (currentState)
		{
		case AIState.Idle:
			ChangeState(AIState.ChaseAndAttack);
			break;
		case AIState.ChaseAndAttack:
			DOChase();
			break;
		}
	}

}
