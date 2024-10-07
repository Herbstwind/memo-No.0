using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attckt : lifesystem
{
    // Start is called before the first frame update
    public float damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enermy"))
        {
            collision.GetComponent<lifesystem>().TakeDamage(damage);
            
        }

    }

    
}
