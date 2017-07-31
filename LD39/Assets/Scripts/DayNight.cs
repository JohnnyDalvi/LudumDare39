using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DayNight : MonoBehaviour
{
    Image skyIllumation;
    public Color MidDayColor;
    public Color MidNightColor;
    Color MyColor;
    TimeSpan dayTime;
    TimeSpan timeTick;
    public int MinutesTick;
    public float timeDelayInSeconds;
    float insulation;
    public Text timeText;
    public Text insulationText;
    [Range(0, 24)]public int StartingTime = 6;
    int lastHour;

    void Start()
    {
        dayTime = new TimeSpan(StartingTime, 00, 00);
        timeTick = new TimeSpan(0, MinutesTick, 0);
        skyIllumation = GetComponent<Image>();
        StartCoroutine(timeHappens());
    }

    void ChangeTime()
    {
        dayTime += timeTick;
        string shownTime = string.Format("{0}:{1}", dayTime.Hours, dayTime.Minutes);
        insulation = 1 - (Math.Abs(((float)dayTime.Hours + ((float)dayTime.Minutes / 60) - 12) / 12));
        timeText.text = shownTime;
        insulationText.text = insulation.ToString("0.0 %");

        if (lastHour != dayTime.Hours)
        {
            lastHour = dayTime.Hours;
            Master.ChangeCurrentHour(lastHour, insulation);
        }

        ChangeColor();
    }

    void ChangeColor()
    {
        MyColor = Color.Lerp(MidNightColor, MidDayColor, insulation);
        skyIllumation.color = MyColor;
    }

    IEnumerator timeHappens()
    {
        yield return new WaitForSeconds(timeDelayInSeconds);
        if (!Master.isPaused)
        {
            ChangeTime();
        }
        yield return timeHappens();
    }

    void Update()
    {
    }
}
