using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletUI : MonoBehaviour
{
    [SerializeField] public int Magazines;
    public float ReloadDuration;
    public Text magazine;
    private void Start()
    {
        
        Magazines = 24;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Magazines > 0)
        {
            Magazines--;
            

        }
        else if (Magazines == 0)
        {

            StartCoroutine(nameof(ReloadCoroutine));
        }
        magazine.text = TimeFormatter(Magazines);


    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(ReloadDuration);

        Magazines = 24;




    }
    string TimeFormatter(float time)
    {
        
        return "24/" + Magazines.ToString("D2");
    }
}
