using UnityEngine;

public class SafeHeaven : MonoBehaviour
{
    float timeStep;
    float timeToWin = 2;
    float CountingTime;
    bool Count;

    void Start()
    {
        timeStep = Time.fixedDeltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Count = true;
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
        Count = false;
        CountingTime = 0;
    }
}
