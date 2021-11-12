using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNavigator : MonoBehaviour
{
    public GameObject[] TextBoxes = new GameObject[6];
    public int index = 0;
    public GameObject wisdomLevel;
    bool GameOver = false;

    void Start()
    {
        TextBoxes[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 5) if (wisdomLevel.GetComponent<ButtonPress>().clickIndex == 8) {TextBoxes[index].SetActive(true); GameOver = true; }
    }

    public void OnClick()
    {
            if (index == 5 && GameOver == true) Application.Quit();
        if (index < 5) { index++; if (index == 5) this.gameObject.SetActive(false); }
        if (index < 5) TextBoxes[index].SetActive(true);
        TextBoxes[index - 1].SetActive(false);


    }
}
