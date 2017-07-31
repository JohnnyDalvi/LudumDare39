using UnityEngine;
using UnityEngine.UI;

public class WaterLevel : MonoBehaviour
{
    public static Slider waterSlider;
    public float maximumWater;
    float currentWater;
    public float ReplenishRate;
    public float depleateRate;
    float currentDepleateRate;
    bool onTopOfWater;

    void Start()
    {
        currentWater = maximumWater;
        Master.OnHourChange += TimeOfDay;
        UpdateSlider();
    }


    void ClampWater()
    {
        if (currentWater <= 0)
        {
            currentWater = 0;
            Master.LoseGame();
        }
        if (currentWater >= maximumWater)
        {
            currentWater = maximumWater;
        }
        UpdateSlider();
    }

    void TimeOfDay(float hour, float insulation)
    {
        currentDepleateRate = depleateRate * insulation + 1;
    }

    void FixedUpdate()
    {
        DepleateRate();
    }

    void UpdateSlider()
    {
        waterSlider.value = currentWater / maximumWater;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
            onTopOfWater = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
            onTopOfWater = false;
    }


    void DepleateRate()
    {
        if (onTopOfWater == false)
        {
            currentWater -= currentDepleateRate;
        }
        else
        {
            currentWater += ReplenishRate;
        }
        ClampWater();
    }

    public void TakeDamage(float amount)
    {
        currentWater -= amount;
        ClampWater();
    }
}

