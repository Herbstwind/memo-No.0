using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnermyLifeSystem : MonoBehaviour
{
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float CurrentHealth;
    public UnityEvent OnHurt;
    public UnityEvent OnDead;

    protected virtual void OnEnble()
    {
        CurrentHealth = MaxHealth;
    }

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }


    // Start is called before the first frame update
    public virtual void TakeDamage(float damage)
    {
        
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0f)
        {

            Die();
        }

    }
    public virtual void Die()
    {
        CurrentHealth = 0f;

        OnDead?.Invoke();
    }


    
}
