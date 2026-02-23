using UnityEngine;
[RequireComponent(typeof(Collider))]


public class DamageOnOverlap : MonoBehaviour
{
	public float damageDone;
	private Collider _collider;
	
	public void Start()
	{
		_collider = GetComponent<Collider>();
		_collider.isTrigger = true;
	}   

	public void OnTriggerEnter(Collider other)
	{
	Health otherHealth = other.GetComponent<Health>();
	if (otherHealth != null)
		{
		otherHealth.TakeDamage(damageDone);
		}
	Destroy(gameObject);
	}   
}
