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
        }
    }

    void Update()
    {
        UpdateDistance();
    }
}
