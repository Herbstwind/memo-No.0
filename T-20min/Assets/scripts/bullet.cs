using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour 
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private float timer = 0;

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;

    }


    void Update()
    {

        transform.position = speed * direction * Time.deltaTime + (Vector2)transform.position;
        if (timer <= 900)
        {
            timer++;
        }
        else
        {

            timer = 0;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            
        
    }
}

