using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent OnPlayerDeath;

    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;

    public void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage()
    {
        currentHealth -= 3;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Ouch!");
        if(currentHealth <= 0)
        {
            PlayerDeath();
        }
    }
}
