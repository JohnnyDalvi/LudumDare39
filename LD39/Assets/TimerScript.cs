using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    Image timerImage;
    public float timeAmount;
    float currentTime;

    public static TimerScript InstantiateTimer(float time, Vector3 position)
    {
        GameObject timer = Instantiate(Resources.Load("Timer"), position, Quaternion.identity) as GameObject;
        TimerScript myScript = timer.GetComponent<TimerScript>();
        myScript.timeAmount = time;
        return myScript;
    }
    void Start()
    {
        timerImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    public void DestroyTimer()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        ImageRadial();
        if (currentTime >= timeAmount)
        {
            DestroyTimer();
        }
    }

    void ImageRadial()
    {
        timerImage.fillAmount = currentTime / timeAmount;
    }

}
