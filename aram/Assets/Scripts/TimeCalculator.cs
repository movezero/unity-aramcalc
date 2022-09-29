using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeCalculator : MonoBehaviour
{
    // public GameObject dateText;
    // public GameObject timeText;
    public DateTime now;
    public DateTime later;

    void Start()
    {
        now = DateTime.Now;
        later = new DateTime(2022, 09, 30, 1, 1, 1);
        TimeSpan ts;
        ts = now - later;
        string nowTime = now.ToString();
        Debug.Log(nowTime);
        Debug.Log(later);
        Debug.Log(ts);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
