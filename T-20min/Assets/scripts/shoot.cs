using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float interval;
    public GameObject bullet;
    public Transform muzzle;
    private Vector2 mousepos;
    private Vector2 direction;
    private float timer;
    private float flipY;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        muzzle = transform.Find("muzzle");
        flipY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        if (mousepos.x < transform.position.x)
            transform.localScale = new Vector3(flipY, -flipY, 1);
        else
            transform.localScale = new Vector3(flipY, flipY, 1);

        shot();

    }
    void shot()
    {
        direction = (mousepos - new Vector2(transform.position.x ,transform.position.y)).normalized;
        transform.right = direction;

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                timer = 0;
        }

        if (Input.GetMouseButton(0))
        {
            if (timer == 0)
            {
                Fire();
                timer = interval;
            }
        }

    
    
    }
    void Fire()
    {
        GameObject temp = Instantiate(bullet, muzzle.position, Quaternion.identity);
        temp.GetComponent<bullet>().SetDirection(direction);
    }
}
