using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class timer : MonoBehaviour
{
    public Text timetext;
    private float currenttime;

    private void Update()
    {
        currenttime += Time.deltaTime;
        timetext.text = TimeFormatter(currenttime);
    }
    string TimeFormatter(float time)
    {
        int min = (int)time / 60;
        int sec = (int)time- min * 60;
        return min.ToString("D2") + ":" + sec.ToString("D2");
    }
}
