using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : lifesystem
{
    public float damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<lifesystem>().TakeDamage(damage);
        }
    }
}
