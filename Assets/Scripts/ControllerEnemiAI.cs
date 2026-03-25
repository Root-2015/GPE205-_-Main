using UnityEngine;

public enum AIState {ChoosingRoamDirection,Roam,Attack,ChaseAndAttack,Flee,Chase,Idle,Patrol}



public abstract class ControllerEnemiAI : Controller
{
	private Quaternion roamDirection = Quaternion.identity;
	private float transitionChangeTime;
	protected AIState currentState = AIState.Idle;
	public Transform target;
	public float FleeDistance = 5;
	public float hearingDistance;
	public float visionDistance;
	public float fieldOfVeiw;


public override void Start()
	{
	pawn = GetComponent<Pawn>();
	transitionChangeTime = Time.deltaTime;
	target = GameObject.Find("Player(Clone)").GetComponent<Transform>();
	}


public void ChangeState (AIState newState)
	{
	currentState = newState;
	transitionChangeTime = Time.time;
	}

public void DoIdle()
	{
	//Does nothing
	}



public void DoRoam(){}

public void DOChase()
	{
	Search(target.position);
	}

public void DoFlee()
	{
	Vector3 vectorToTarget = pawn.transform.position - target.position;

	float distanceToPlayer = vectorToTarget.magnitude;
	vectorToTarget.Normalize();
	float percentOfFleeDistance= (distanceToPlayer/FleeDistance);
	percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
	float flipPercentOfFleeDistance = 1-percentOfFleeDistance;
	float newFleeDistance = flipPercentOfFleeDistance *FleeDistance;
	Vector3 targetPosition = pawn.transform.position + (vectorToTarget * newFleeDistance);
	Search(targetPosition);
	}


public void Search(Vector3 position)
	{
	pawn.RotateTowards(position);
	pawn.Move(new Vector2(0,1));

	}

     public override void OnDestroy()
	{
	GameManager.instance.players.Remove(this);
	Destroy(gameObject);
	}

public bool CanSee (Transform target)
	{
	float totalDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
	if (totalDistance <= visionDistance) 
	{
		Vector3 angle = target.transform.position - pawn.transform.position;
		float angleToTarget = Vector3.Angle(angle, pawn.transform.forward);
        	if (angleToTarget < fieldOfVeiw) 
        	{
            	return true;
        	}
		else {return false;}
	}
	else {return false;}

	}


public bool CanHear (Transform target)
	{
	NoicceMaker targetNoiceMaker = target.GetComponent<NoicceMaker>();
	if (targetNoiceMaker == null) {return false;}
	if (targetNoiceMaker.noiceVolume > 0)
		{
		float totalDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
		if (totalDistance <= targetNoiceMaker.noiceVolume+hearingDistance) {return true;}
		else {return false;}
		}
	else {return false;}

	}

















}
