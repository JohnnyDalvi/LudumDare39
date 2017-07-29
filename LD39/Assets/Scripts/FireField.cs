using UnityEngine;
public class FireField : MonoBehaviour
{
    WaterLevel waterLevel;
    public float Damage;
    bool isOnFire;

    void Start()
    {
        waterLevel = SunFlower.instance.GetComponent<WaterLevel>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SunFlower>())
            isOnFire = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<SunFlower>())
            isOnFire = false;
    }

    void FixedUpdate()
    {
        if (isOnFire)
        {
            waterLevel.TakeDamage(Damage);
        }
    }
}
