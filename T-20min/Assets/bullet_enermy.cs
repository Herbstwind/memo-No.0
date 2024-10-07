using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enermy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private Vector2 direction;
    private float timer = 0;
    [SerializeField] private Transform player;



    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        direction = (player.position - transform.position).normalized;
        transform.position = speed * direction * Time.deltaTime + (Vector2)transform.position;
        if (timer <= 900)
        {
            timer++;
        }
        else
        {

            timer = 0;
            Destroy(this.gameObject);
        }

    }
}
