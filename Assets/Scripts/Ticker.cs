using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    public TickerItem tickerItemPrefab;
    [Range(1f,10f)]
    public float itemDuration = 3.0f;
    public string[] newsItems;

    float width;
    float PixelsPerSecond;
    TickerItem currentItem;

    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        PixelsPerSecond = width / itemDuration;
        AddTickerItem(newsItems[0]);
    }

    void Update()
    {
        if (currentItem.GetXPosition <= -currentItem.GetWidth)
        {
            AddTickerItem(newsItems[Random.Range(0, newsItems.Length)]);
        }
    }

    void AddTickerItem(string news)
    {
        currentItem = Instantiate(tickerItemPrefab, transform);
        currentItem.Initialize(width, PixelsPerSecond, news);
    }
}
