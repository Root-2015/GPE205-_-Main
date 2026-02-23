using UnityEngine;

public class ControllerEnemyRunaway : ControllerEnemiAI
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
			if (CanSee(target)) {ChangeState(AIState.Flee);}
			else{DoIdle();}
			break;
		case AIState.Flee:
			if (CanSee(target)) {DoFlee();}
			else {ChangeState(AIState.Idle);}
			break;
		}
	}

}
