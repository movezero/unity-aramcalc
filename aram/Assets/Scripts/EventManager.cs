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
    static int remainDays = 79;    //  시간에 따라 자동으로 변경 필요
    int aramWork = remainDays * 3 + 1;  // TimeCalculator에서 1씩 값 변경을 위해 새로운 변수 선언 및 초기화

    void Start()
    {
        userInput = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>(); // InputField 컴포넌트에 접근 
        myTickets = PlayerPrefs.GetInt("tickets");  // 이전에 실행했을 때 저장했던 myTickets 값을 불러옴
        textDisplay.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("display");    // PlayerPrefs 에 저장된 문자열 불러옴
        userInput.text = myTickets.ToString();  // InputField 에 myTickets값을 보이게 하기 위해 문자열로 변경 후 대입

        Debug.Log(PlayerPrefs.GetString("display"));
        Debug.Log(PlayerPrefs.GetInt("tickets"));
        //Test();
    }
    public void StoreTicket()
    {
        //myTickets = (int.TryParse(_inputField.GetComponent<TextMeshPro>().text, out myTickets)) ? myTickets : -1; //정수 입력받기
        myTickets = int.Parse(userInput.text);
        float meal_per_day = myTickets / ((aramWork) / 3.0f); // 계산식
        string result = string.Format("하루에 {0:0.##}끼 씩 먹으면 다 먹을 수 있습니다.", meal_per_day);    // 소수점 두 번째 자리에서 반올림
        Save(result);
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
    public void Save(string result1)
    {
        PlayerPrefs.SetInt("tickets", myTickets);   // 메모리에 정수값 저장
        PlayerPrefs.SetString("display", result1);    // 메모리에 문자열 저장
        PlayerPrefs.Save();     // 수정된 모든 preferences를 파일(드라이브)에 저장한다.
    }

    public void AllDelete()    // 저장되어 있는 모든 데이터 삭제하기   PlayerPrefs 초기화 
    {
        PlayerPrefs.DeleteAll();
    }

    public void TicketsDelete()     // tickets 키를 가진 데이터 삭제
    {
        PlayerPrefs.DeleteKey("tickets");
    }
    public void DisplayDelete()      // display 키를 가진 데이터 삭제
    {
        PlayerPrefs.DeleteKey("display");
    }






    public void Test()  // 명시적 형변환 테스트
    {
        int num = 50000;
        short smallNum = (short)num;
        char stringNum = (char)num;
        Debug.Log(smallNum);
        Debug.Log(stringNum);

        string a = "1234";
        //int b = (int)a;     // 오류
        int b = int.Parse(a);   // string 형식의 a를 int로 변환

        string c = "3.14";
        //double d = (double)c;
        double d = double.Parse(c);
        float f = float.Parse(c);
    }

}

// int remain_days = 89;   // 종강까지 남은 일수 12월21일 아침까지 운영
// int last_morning = 1;   // 종강 당일 아침
// float my_ticket = 167;  // 내 남은 식권

// float aram_make_meal = remain_days * 3 + last_morning; // 아람관 밥 하는 회수
// float meal_per_day = (my_ticket / (aram_make_meal / 3));



// Debug.Log(aram_make_meal);
// Debug.Log(meal_per_day);