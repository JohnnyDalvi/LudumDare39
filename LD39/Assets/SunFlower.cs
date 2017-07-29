using UnityEngine;

public class SunFlower : MonoBehaviour
{

    public float moveSpeed;
    public float speedInsulation;
    float initialSpeedInsulation;
    float horizontal;
    float vertical;
    float speedMultiplier;

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
        if (Input.GetKey(KeyCode.A))
            horizontal = -1;
        else if (Input.GetKey(KeyCode.D))
            horizontal = 1;
        else
            horizontal = 0;

        if (Input.GetKey(KeyCode.W))
            vertical = 1;
        else if (Input.GetKey(KeyCode.S))
            vertical = -1;
        else
            vertical = 0;
    }

    void FixedUpdate()
    {
        Vector2 MoveVector = new Vector2(horizontal, vertical).normalized;
        MoveVector = new Vector2(MoveVector.x * speedMultiplier, MoveVector.y * speedMultiplier);
        transform.position += new Vector3(MoveVector.x, MoveVector.y, 0);
    }

    void InsulationEffect(float hour, float insulation)
    {
        speedInsulation = initialSpeedInsulation * insulation;
        speedMultiplier = (moveSpeed + speedInsulation) * Time.fixedDeltaTime;
    }
}
