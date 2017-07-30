﻿using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public float timeToOpen;
    float countingTime;
    bool isActive;
    bool hasOpened;
    public DoorRotor door;
    SpriteRenderer myImage;

    void Start()
    {
        myImage = GetComponent<SpriteRenderer>();
    }

    void ChangeColor(bool white)
    {
        if (white)
            myImage.color = Color.white;
        else
            myImage.color = Color.gray;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ChangeColor(false);
        if (other.GetComponent<SunFlower>())
        {
            isActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ChangeColor(true);
        if (hasOpened = true)
        {
            StartCoroutine(door.CloseDoorEnum());
        }

        if (other.GetComponent<SunFlower>())
        {
            isActive = false;
            hasOpened = false;
            countingTime = 0;
        }
    }

    void Update()
    {
        if (isActive)
        {
            countingTime += Time.deltaTime;
            if (countingTime >= timeToOpen)
            {
                hasOpened = true;
                door.OpenDoor();
            }
        }
    }
}
