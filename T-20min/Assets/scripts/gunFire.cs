using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class gunFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;
    private Vector2 direction;
    private float flipY;
    [SerializeField] public int Magazines;
    
    public float ReloadDuration;


    // Update is called once per frame

    private void Start()
    {
        flipY = transform.localScale.y;
        Magazines = 24;
    }
    void Update()
    {
        if (direction.x < transform.position.x)
            transform.localScale = new Vector3(flipY, -flipY, 1);
        else
            transform.localScale = new Vector3(flipY, flipY, 1);

        if (Input.GetMouseButtonDown(0) && Magazines > 0)
        {
            Magazines--;
            GameObject temp = Instantiate(bullet, muzzle.position, Quaternion.identity);
            temp.GetComponent<bullet>().SetDirection(direction);

        }
        else if (Magazines == 0)
        {
            
            StartCoroutine(nameof(ReloadCoroutine));
        }

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(ReloadDuration);

        Magazines = 24;

        


    }

}
