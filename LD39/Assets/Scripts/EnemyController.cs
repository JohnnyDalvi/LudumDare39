using UnityEngine;

public partial class EnemyController : MonoBehaviour
{
    public Vector3 target;
    public float Damage = 50;
    public float KnockBackTime = 1;
    public float KnockBackPower = 10;
    public float moveSpeed = 1;
    protected Vector3 waypoint;
    public bool isStatic;


    void MoveTo(Vector3 target)
    {
        MoveDirection(target);
    }

    void FixedUpdate()
    {
        if (!isStatic)
            MoveTo(WayPointChoser());
    }

    protected virtual Vector3 WayPointChoser()
    {
        return waypoint;
    }

    protected virtual void MoveDirection(Vector3 target)
    {

    }
}