using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brr : MonoBehaviour
{
    public float credits = 0;
    public int creditsIncreaseRateClick= 1;
    public int creditsIncreaseRateAuto = 1;
    public bool autoCreditsOn = false;
    public Text creditsText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (autoCreditsOn == true) GetAutoCredits();
        creditsText.text = ((int)credits).ToString();
    }

    public void GetCredits()
    {
        credits += creditsIncreaseRateClick;
        if (credits > 999998) credits = 999998;
    }

    public void TurnAutoCreditsOn()
    {
        autoCreditsOn = true;
    }

    public void GetAutoCredits()
    {
        credits += creditsIncreaseRateAuto * Time.deltaTime;
        if (credits > 999998) credits = 999998;
    }
}
