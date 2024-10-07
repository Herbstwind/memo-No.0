using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnermyController : MonoBehaviour
{
    [Header("属性")]
    [SerializeField] private float currentSpeed = 0f;
    private Vector2 movementInput {get;set;}
    [Header("攻击属性")]
    [SerializeField] private bool isAttack = true;
    [SerializeField] private float AttackCoolDuration = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Vector2 direction;

    private bool IsDead;

    [Header("远程")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }



    



    private void FixedUpdate()
    {
        direction = GameObject.Find(this.name).GetComponent<enermyControlller>().direction;
        if(!IsDead)
            Move();
    }

    void Move()
    {
        
        if(direction.magnitude > 0.1f && currentSpeed > 0)
        {
            
            rb.velocity = currentSpeed * direction;

            if (direction.x < 0f)
            {
                
                sr.flipX = true;

            }
            if (direction.x > 0f)
            {
                sr.flipX = false;
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
            
        }
    }

    public void EnermyDead() 
    {
        IsDead = true;
        SetAnim();
    }
    void SetAnim() 
    {
        
        anim.SetBool("IsDead", IsDead);
    }

    public void DestroyEnermy()
    {
        Destroy(this.gameObject);

        //击退机制 
    }
    public void Attack()
    {
        if (isAttack = true)
        {
            isAttack = false;
            StartCoroutine(nameof(AttackCoroutine));
        }
        
    }
    IEnumerator AttackCoroutine() 
    {
        GameObject temp = Instantiate(bullet, muzzle.position, Quaternion.identity);
        yield return new WaitForSeconds(AttackCoolDuration);
        isAttack = true;

    }

}
