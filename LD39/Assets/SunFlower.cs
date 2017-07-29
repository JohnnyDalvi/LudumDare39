using UnityEngine;

public class SunFlower : MonoBehaviour
{

    public float moveSpeed;
    public float speedInsulation;
    float initialSpeedInsulation;

    void Start()
    {
        initialSpeedInsulation = speedInsulation;
        Master.OnHourChange += InsulationEffect;
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 MoveVector = new Vector2(horizontal, vertical).normalized;
        MoveVector = new Vector2((MoveVector.x * (moveSpeed + speedInsulation)) * Time.deltaTime, (MoveVector.y * (moveSpeed + speedInsulation) * Time.deltaTime));
        print(MoveVector);
        transform.Translate(MoveVector.x, MoveVector.y, 0);
    }

    void InsulationEffect(float hour, float insulation)
    {
        speedInsulation = initialSpeedInsulation * insulation;
        print("changedSpeed");
    }
}
