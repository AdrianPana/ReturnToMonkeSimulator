using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    int credits;
    public int price;
    public string roleName;
    public GameObject button;
    public Button myButton;
    private GameObject child;
    public Text wisdomText;
    public GameObject NextButton;
    public AudioSource soundEffect;
    int[] MorePerClickPrice = new int[] { 10, 20, 40, 80, 120, 175, 240, 310, 400, 500, 999999 };
    int[] AutoPrice = new int[] { 50, 100, 150, 200, 400, 750, 1000, 1500, 999999 };
    int[] WisdomPrice = new int[] { 20, 100, 250, 500, 1000, 2000, 5000, 10000, 999999 };
    int[] AutoCreditsRates = new int[] { 1, 4, 8, 12, 18, 25, 40, 60, 90, 125 };
    string[] MonkeWisdom = new string[] {"zero","\"We've been tricked, we've been bananastabbed, and we've been quite possibly, baboonzled\" - Monke Chief",
        " \"Yes, we can\" - Barack Obanana",
        " \"He who loves banana, loves himself\" - Monko, Monk Monkey",
        " \"To reach the ape-solute, you don't just search for banana, you understand banana\" - Aperistotle",
        " \"Banana, therefore I am. \" - Monkartes ",
        " \"Being an absolute monkey is eating the same banana over and over again and expecting different poop\" - Ape-rt Ape-instein",
        " \"You lose 100% of the bananas you don't take\" - Lee Monkey Oswald",
        " \"You must be the banana you want to eat in this world\" - Mahatma Monkey"
    };

   public GameObject[] hiredMonkeys = new GameObject[8];

    public int clickIndex = 0, autoIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        child = button.transform.GetChild(0).gameObject;
       child.GetComponent<Text>().text = price.ToString();

        credits = (int)GameObject.FindGameObjectWithTag("Powerhouse").GetComponent<brr>().credits;
        if (credits < price)  myButton.enabled = false;  
        else myButton.enabled = true; 
    }

    public void BuyAutoCredits()
    {   
        autoIndex++;
        soundEffect.Play();

        GameObject.FindGameObjectWithTag("Powerhouse").GetComponent<brr>().credits -= price;
        GameObject.FindGameObjectWithTag("Powerhouse").GetComponent<brr>().creditsIncreaseRateAuto = AutoCreditsRates[autoIndex];

        price = AutoPrice[autoIndex];
        hiredMonkeys[autoIndex - 1].SetActive(true);
    }

    public void BuyMoreCreditsPerClick()
    {
        GameObject.FindGameObjectWithTag("Powerhouse").GetComponent<brr>().credits -= price;
        GameObject.FindGameObjectWithTag("Powerhouse").GetComponent<brr>().creditsIncreaseRateClick++;

        clickIndex++;


        price = MorePerClickPrice[clickIndex];
    }

    public void BuyWisdom()
    {
        GameObject.FindGameObjectWithTag("Powerhouse").GetComponent<brr>().credits -= price;

        clickIndex++;
        soundEffect.Play();

        price = WisdomPrice[clickIndex];
        wisdomText.text = MonkeWisdom[clickIndex];

        if (clickIndex == 8) NextButton.SetActive(true);
    }
}
