using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public TMP_InputField userInput;    // string
    public GameObject textDisplay;
    public int myTickets = 159;  //  나의 남은 식수, int
    public int remainDays = 86;    //  시간에 따라 자동으로 변경 필요

    void Start()
    {
        userInput = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        myTickets = PlayerPrefs.GetInt("tickets");
        textDisplay.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("display", "result");
        userInput.text = myTickets.ToString();
    }
    public void StoreTicket()
    {
        //myTickets = (int.TryParse(_inputField.GetComponent<TextMeshPro>().text, out myTickets)) ? myTickets : -1; //정수 입력받기
        myTickets = int.Parse(userInput.text);
        float meal_per_day = myTickets / ((remainDays * 3 + 1) / 3.0f); // 계산식
        string result = string.Format("하루에 {0:0.##}끼 씩 먹으면 다 먹을 수 있습니다.", meal_per_day);    // 소수점 두 번째 자리에서 반올림
        Save();
        textDisplay.GetComponent<TextMeshProUGUI>().text = result;  // 계산 결과를 화면에 나타내기 
    }
    public void Plus() // + 버튼 클릭 시
    {
        myTickets += 1;
        userInput.text = myTickets.ToString();  // 몇 끼 입력했는지 화면에 나타내기
        StoreTicket();
    }
    public void Minus()
    {
        myTickets -= 1;
        userInput.text = myTickets.ToString();  // 몇 끼 입력했는지 화면에 나타내기
        StoreTicket();

    }
    public void Save()
    {
        PlayerPrefs.SetInt("tickets", myTickets);
        PlayerPrefs.SetString("display", "result");
        PlayerPrefs.Save();     // 수정된 모든 preferences를 파일에 저장한다.
    }
}

// int remain_days = 89;   // 종강까지 남은 일수 12월21일 아침까지 운영
// int last_morning = 1;   // 종강 당일 아침
// float my_ticket = 167;  // 내 남은 식권

// float aram_make_meal = remain_days * 3 + last_morning; // 아람관 밥 하는 회수
// float meal_per_day = (my_ticket / (aram_make_meal / 3));



// Debug.Log(aram_make_meal);
// Debug.Log(meal_per_day);