using UnityEngine;

public class Health : MonoBehaviour
{
	[HideInInspector]public float currentHealth;
	public float maxHealth;
	public Pawn pawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	pawn = GetComponent<Pawn>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float amount) 
	{
		currentHealth = currentHealth - amount;
		if (currentHealth <= 0)
		{
		Die();
		}
	}
    public void heal (float amount) 
	{
		currentHealth = currentHealth + amount;
		if (currentHealth > maxHealth){currentHealth = maxHealth;}
	}

    public void Die () 
	{
	Debug.Log("Ouch");
	pawn.OnDestroy();
	}



}
