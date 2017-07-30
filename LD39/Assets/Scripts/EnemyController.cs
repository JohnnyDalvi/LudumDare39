using UnityEngine;

public partial class EnemyController : MonoBehaviour
{
    public float Damage = 50;
    public float KnockBackTime = 1;
    public float KnockBackPower = 10;
    public float moveSpeed = 1;
    protected Vector3 waypoint;
    public float AngloDoSprite;
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

    protected void lookAtDirection(Vector3 target)
    {

        Vector3 toTarget = target - gameObject.transform.position;
        toTarget.Normalize();
        Vector3 curVel = (transform.position - target) / Time.deltaTime;
        if (curVel != Vector3.zero)
        {

            float angle = Mathf.Atan2(curVel.y, curVel.x) * Mathf.Rad2Deg + AngloDoSprite;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
}
