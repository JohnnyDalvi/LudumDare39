using UnityEngine;

public class SunFlower : MonoBehaviour
{

    public float moveSpeed;
    public float speedInsulation;
    float initialSpeedInsulation;
    float horizontal;
    float vertical;
    float speedMultiplier;
    static bool Stunned;
    static float StunnedTime;
    static SunFlower _instance;
    Animator myAmin;
    WaterLevel waterLevel;
    Rigidbody2D myRig;
    public static SunFlower instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SunFlower>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        myAmin = GetComponent<Animator>();
        myRig = GetComponent<Rigidbody2D>();
        waterLevel = GetComponent<WaterLevel>();
        _instance = this;
        initialSpeedInsulation = speedInsulation;
        Master.OnHourChange += InsulationEffect;
    }
    void Update()
    {
        Movement();

    }

    void Movement()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal = 1;
        else
            horizontal = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            vertical = 1;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            vertical = -1;
        else
            vertical = 0;
    }

    void FixedUpdate()
    {
        ProcessStunTime();
        if (!Stunned)
        {
            Vector2 MoveVector = new Vector2(horizontal, vertical).normalized;
            MoveVector = new Vector2(MoveVector.x * speedMultiplier, MoveVector.y * speedMultiplier);
            float animSpeed = (MoveVector.magnitude * 100);
            if (animSpeed >= 0.5f)
            {
                myAmin.SetFloat("Speed", animSpeed);
                myAmin.speed = animSpeed;
            }
            else
            {
                myAmin.SetFloat("Speed", 0);
                myAmin.speed = 1;

            }
            Vector3 walkingDirection = new Vector3(MoveVector.x, MoveVector.y, 0);
            transform.position += walkingDirection;
            lookAtDirection(transform.position + walkingDirection);
        }
    }

    void lookAtDirection(Vector3 target)
    {

        Vector3 toTarget = target - gameObject.transform.position;
        toTarget.Normalize();
        Vector3 curVel = (transform.position - target) / Time.deltaTime;
        if (curVel != Vector3.zero)
        {

            float angle = Mathf.Atan2(curVel.y, curVel.x) * Mathf.Rad2Deg + 180;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    void ProcessStunTime()
    {
        if (StunnedTime > 0)
        {
            StunnedTime -= Time.fixedDeltaTime;
            Stunned = true;
        }
        else
        {
            StunnedTime = 0;
            Stunned = false;
        }

    }

    void InsulationEffect(float hour, float insulation)
    {
        speedInsulation = initialSpeedInsulation * insulation;
        speedMultiplier = (moveSpeed + speedInsulation) * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            if (!enemy)
                enemy = other.gameObject.GetComponent<CaterpillarBody>().headReference;
            waterLevel.TakeDamage(enemy.Damage);
            Vector2 knockVector2 = new Vector2(transform.position.x - enemy.transform.position.x, transform.position.y - enemy.transform.position.y);
            KnockBack(enemy.KnockBackTime, enemy.KnockBackPower, knockVector2);
        }
    }

    public void KnockBack(float time, float power, Vector2 direction)
    {
        if (time >= 0)
        {
            if (StunnedTime <= time)
            {
                StunnedTime = time;
            }
        }
        myRig.AddForce(NormalizeVectorAndAddPower(direction, 50));
    }

    Vector2 NormalizeVectorAndAddPower(Vector2 direction, float power)
    {
        direction.Normalize();
        return direction * power;
    }
}

