using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Image image;
    public float fillPersent;
    public float healthAmount;
    public float maxHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        fillPersent = image.fillAmount;
        healthAmount = health.currentHealth;
        maxHp = health.maxHealth;
    }

    public void Hurt()
    {
        image.fillAmount = health.currentHealth / maxHp;
    }
}