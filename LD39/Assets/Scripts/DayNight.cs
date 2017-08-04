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
    //public Text timeText;
    //public Text insulationText;
    [Range(0, 24)] public int StartingTime = 6;
    public Transform pointer;
    Quaternion pointerRotation;
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
        //string shownTime = string.Format("{0}:{1}", dayTime.Hours, dayTime.Minutes);
        insulation = 1 - (Math.Abs(((float)dayTime.Hours + ((float)dayTime.Minutes / 60) - 12) / 12)); // interpolation happens here
        //timeText.text = shownTime;
        //insulationText.text = insulation.ToString("0.0 %");

        if (lastHour != dayTime.Hours)
        {
            lastHour = dayTime.Hours;
            Master.ChangeCurrentHour(lastHour, insulation);
        }
        float euAngles = 360 - (dayTime.Hours + ((float)dayTime.Minutes / 60f)) * 15f;
        pointerRotation = Quaternion.Euler(0, 0, euAngles);
        pointer.rotation = pointerRotation;

        ChangeColor();
    }

    void ChangeColor()
    {

        MyColor = Color.Lerp(MidNightColor, MidDayColor, insulation);
        MyColor.a = Mathf.Lerp(MidNightColor.a, MidDayColor.a, interpolation(insulation));
        skyIllumation.color = MyColor;
    }

    float interpolation(float x)
    {
        float temp;
        float factor = 0.85f;

        if (factor == 1f)
            temp = (1f - (1f - x) * (1f - x));
        else
            temp = (1f - Mathf.Pow((1f - x), 2f * factor));

        if (temp <= 0.2f)
            temp = 0.2f;

        //if (temp >= 0.8f)
        //    temp = 0.8f;

        return temp;
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
