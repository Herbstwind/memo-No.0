using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    Vector2 moveDirection;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate" + Time.deltaTime);
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        animator.SetFloat("horizontial",MoveX);
        animator.SetFloat("speed", moveDirection.sqrMagnitude);
        moveDirection = new Vector2 (MoveX, MoveY).normalized;

        rb.velocity = moveDirection * MoveSpeed;
    }
}
