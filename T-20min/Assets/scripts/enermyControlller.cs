using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enermyControlller : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance = 1000f;
    [SerializeField] private float attackDistance = 5f;
    public UnityEvent<Vector2> OnMovementInput;
    public Vector2 direction;
    public UnityEvent OnAttack;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= attackDistance)
        {
            direction = (player.position - transform.position).normalized;
            OnAttack?.Invoke();

        }
        else
        {
            direction = (player.position - transform.position).normalized;
        }
        
        
        





    }
}
