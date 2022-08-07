using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float totalHealth;
    public float currentHealth;

    private HealthBarUI bar;

    private void Start()
    {
        currentHealth = totalHealth;
        bar = GetComponentInChildren<HealthBarUI>();
    }

    public void TakeDamage(float damageAmout)
    {
        currentHealth -= damageAmout;
        bar.SetBarValue(currentHealth);
        CheckDeath();
    }

    public bool CheckDeath()
    {
        if (currentHealth > 0) return false;
        return true;
       
    }
}

