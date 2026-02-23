using UnityEngine;

public class ControllerEnemy : ControllerEnemiAI
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
			if (CanSee(target)) {ChangeState(AIState.ChaseAndAttack);}
			else{DoIdle();}
			break;
		case AIState.ChaseAndAttack:
			DOChase();
			break;
		}
	}
}
