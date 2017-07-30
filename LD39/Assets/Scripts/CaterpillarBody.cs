using UnityEngine;

public class CaterpillarBody : MonoBehaviour
{

    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public float maximumDistance;
    [HideInInspector]
    public CaterpillarController headReference;

    void UpdateDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 normalVect = target.transform.position - transform.position;
        normalVect.Normalize();
        if (distance >= maximumDistance)
        {
            float difference = distance - maximumDistance;
            transform.position += normalVect * difference;
            lookAtDirection(target.position);
        }
    }

    void lookAtDirection(Vector3 Target)
    {

        Vector3 toTarget = Target - gameObject.transform.position;
        toTarget.Normalize();
        Vector3 curVel = (transform.position - Target) / Time.deltaTime;
        if (curVel != Vector3.zero)
        {

            float angle = Mathf.Atan2(curVel.y, curVel.x) * Mathf.Rad2Deg + 270;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    void Update()
    {
        UpdateDistance();
    }
}
