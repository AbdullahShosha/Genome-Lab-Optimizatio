using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{
    public Text ScreenText;
    public static int Timer, Speed, Temp;
    public int IncreaseBy;



    private void Start()
    {
        ResetValues();
    }
    public void SetTimer(int Value)
    {
        Timer += Value;
        ScreenText.text = Timer.ToString();
    }
    public void SetSpeed(int Value)
    {
        Speed += Value;
        ScreenText.text = Speed.ToString();
    }
    public void SetTemp(int Value)
    {
        Temp += Value;
        ScreenText.text = Temp.ToString();
    }
    public void ResetValues()
    {
        Timer = 0; Speed = 0;Temp = 0;
        ScreenText.text = Timer.ToString();
    }
}
