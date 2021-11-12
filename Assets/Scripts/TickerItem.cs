using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickerItem : MonoBehaviour
{
    float tickerWidth;
    float pixelsPerSecond;
    RectTransform rt;

    public float GetXPosition { get { return rt.anchoredPosition.x; } }
    public float GetWidth { get { return rt.rect.width; } }

    public void Initialize(float tickerWitdh, float pixelsPerSecond, string news)
    {
        this.tickerWidth = tickerWidth;
        this.pixelsPerSecond = pixelsPerSecond;
        rt = GetComponent<RectTransform>();
        GetComponent<Text>().text = news;
    }

    void Update()
    {
        rt.position += Vector3.left * pixelsPerSecond * Time.deltaTime;
        if (GetXPosition <= -850- tickerWidth - GetWidth)
        {
            Destroy(gameObject);
        }
    }
}
