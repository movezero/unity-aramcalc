using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public TMP_InputField userInput;
    public GameObject textDisplay;
    public int myTickets = 159;  //  나의 남은 식수
    public int remainDays = 87;    //  시간에 따라 자동으로 변경 필요

    void Start()
    {
        userInput = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }
    public void StoreTicket()
    {
        //myTickets = (int.TryParse(_inputField.GetComponent<TextMeshPro>().text, out myTickets)) ? myTickets : -1; //정수 입력받기
        myTickets = int.Parse(userInput.text);
        // 계산하기, 소수점 두 번째 자리에서 반올림
        float meal_per_day = myTickets / ((remainDays * 3 + 1) / 3.0f);
        string result = string.Format("하루에 {0:0.##}끼 씩 먹으면 다 먹을 수 있습니다.", meal_per_day);

        textDisplay.GetComponent<TextMeshProUGUI>().text = result;
    }
    public void Plus() // + 버튼 클릭 시
    {
        myTickets += 1;
        userInput.text = myTickets.ToString();
        StoreTicket();
    }
    public void Minus()
    {
        myTickets -= 1;
        userInput.text = myTickets.ToString();
        StoreTicket();

    }
}

// int remain_days = 89;   // 종강까지 남은 일수 12월21일 아침까지 운영
// int last_morning = 1;   // 종강 당일 아침
// float my_ticket = 167;  // 내 남은 식권

// float aram_make_meal = remain_days * 3 + last_morning; // 아람관 밥 하는 회수
// float meal_per_day = (my_ticket / (aram_make_meal / 3));



// Debug.Log(aram_make_meal);
// Debug.Log(meal_per_day);