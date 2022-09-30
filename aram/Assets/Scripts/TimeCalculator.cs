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
        later = new DateTime(2022, 09, 30, 0, 0, 0);
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

    //     00:00 기준 시작 (분 단위로 작성)

    // 하루는 1440 분 (24 * 60)

    // 평일 기준

    // 09:30 에 1 차감 (570분이 지난 후)

    // 13:30 에 1 차감 (240분이 지난 후)

    // 19:00 에 1 차감 (330분이 지난 후)

    // 다음 날 09:30 에 1 차감 (1410분이 지난 후)

    // 이후 반복…
}
