using UnityEngine;
[RequireComponent(typeof(Collider))]

public class Pickup : MonoBehaviour
{
	public Collider _collider;


	public virtual void Start()
	{
		_collider = GetComponent<Collider>();
		_collider.isTrigger = true;
	}   

	public virtual void OnTriggerEnter(Collider other)
	{
	
	}

}
