using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeCalculator : MonoBehaviour
{
    public DateTime now;
    public DateTime standard;
    TimeSpan timeDiff;  // 앱을 하루에 여러 번 실행했을 때 중복해서 값을 감산하지 않도록 조치가 필요함.

    void Start()
    {
        now = DateTime.Now;
        standard = new DateTime(2022, 10, 1, 0, 0, 0);
        timeDiff = now - standard;
        // string nowTime = now.ToString();

        if (timeDiff.Days > 0)
        {
            EventManager.aramWork -= 3 * timeDiff.Days;
        }
        else
        {

        }
        Debug.Log(now);
        Debug.Log(standard);
        Debug.Log(timeDiff.TotalMinutes);
        Debug.Log(timeDiff.Minutes);
    }

    // Update is called once per frame
    void MinutesCalc()
    {
        if (timeDiff.Minutes > 0)
        {

        }
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
