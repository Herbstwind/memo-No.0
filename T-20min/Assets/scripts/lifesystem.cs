using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class lifesystem : MonoBehaviour
{

   [SerializeField] protected float MaxHealth;
   [SerializeField] protected float CurrentHealth;
    public bool invulnerable;
    public float invulnerableDuration;
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
        if (invulnerable)
            return;
        CurrentHealth -= damage;
        StartCoroutine(nameof(InvulnerableCoroutine));
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

   
    protected virtual IEnumerator InvulnerableCoroutine()
    {
        invulnerable = true;

        yield return new WaitForSeconds(invulnerableDuration);

        invulnerable = false;
    }
    public void PlayerDIe()
    {
        Destroy(gameObject);
        
    }

}
