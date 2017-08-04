using UnityEngine;

public class SafeHeaven : MonoBehaviour
{
    float timeStep;
    float timeToWin = 2;
    float CountingTime;
    bool Count;
    TimerScript timer;

    void Start()
    {
        timeStep = Time.fixedDeltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Count = true;
        timer = TimerScript.InstantiateTimer(timeToWin, transform.position);
    }

    void FixedUpdate()
    {
        if (Count)
        {
            CountingTime += timeStep;
            if (CountingTime >= timeToWin)
            {
                Master.WinGame();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (timer)
            timer.DestroyTimer();
        Count = false;
        CountingTime = 0;
    }
}
