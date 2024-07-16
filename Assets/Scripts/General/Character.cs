using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{

    [Header("Basic Attribute")]
    

    public float maxHealth;
    public float currentHealth;


    [Header("Vulnerable Invincibility")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool invulnerable;

    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if(invulnerableCounter <= 0)
            {
                invulnerable = false;
            }

        }
    }

    public void TakeDamage(Attack attacker)
    {
        if (invulnerable)
            return;

        if(currentHealth - attacker.damage > 0)
        {

       
            // Debug.Log(attacker.damage);
            currentHealth -= attacker.damage;
            TriggerInvulnearable();

            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentHealth = 0;
            OnDie?.Invoke();
        }
    }

    private void TriggerInvulnearable()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
