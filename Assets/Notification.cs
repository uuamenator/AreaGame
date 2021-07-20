using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public GameObject notificationPrefab;
    public Text message;
    public string messageString;
    private float baseX;
    private float baseY;
    private const int NOTIFICATION_SPEED = 1;
    private const int NOTIFICATION_DISTANCE = 80;
    // Start is called before the first frame update
    void Awake()
    {
        this.message.text = messageString;
        baseX = transform.position.x;
        baseY = transform.position.y;
        Debug.Log(baseX);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(baseX, baseY);
    }

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" baseY inside update " + baseY);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y + NOTIFICATION_SPEED);
        if (this.GetComponent<RectTransform>().anchoredPosition.y >= baseY + NOTIFICATION_DISTANCE)
        {
            Destroy(this.gameObject);
        }
    }

    public void Create(float x, float y, string text)
    {
        messageString = text;
        Debug.Log(" Notif Prefab Create baseY " + baseY);
        GameObject notification = Instantiate(notificationPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        notification.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);

        //this.message.text = text;
    }

}
