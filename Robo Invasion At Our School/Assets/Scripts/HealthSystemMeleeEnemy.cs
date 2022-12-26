using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemMeleeEnemy : MonoBehaviour
{
    public float maxHealth=10;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
        UpdateHealthBar();
        if(currentHealth <= 0)
        {
            Die();
        }
        
    }
    public void Die()
        {
            Destroy(gameObject);
        }

    public void UpdateHealthBar()
    {

    }
}
