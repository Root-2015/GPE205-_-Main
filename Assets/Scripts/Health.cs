using UnityEngine;

public class Health : MonoBehaviour
{
	[HideInInspector]public float currentHealth;
	public float maxHealth;
	public Pawn pawn;
	public HealthBar healthBar;
	public float score;
	public ScoreManager scoreKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreManager>();
        pawn = GetComponent<Pawn>();
        currentHealth = maxHealth;
    }

    public void scoreGoal(float amount)
    {
        score = score + amount;
    }


    public void TakeDamage (float amount) 
	{
		currentHealth = currentHealth - amount;
		if (currentHealth <= 0)
		{
		Die();
		}
		healthBar.Hurt();

    }
    public void heal (float amount) 
	{
		currentHealth = currentHealth + amount;
		if (currentHealth > maxHealth){currentHealth = maxHealth;}
        healthBar.Hurt();
    }

    public void Die () 
	{
	Debug.Log("Ouch");
	pawn.OnDestroy();
	}



}
