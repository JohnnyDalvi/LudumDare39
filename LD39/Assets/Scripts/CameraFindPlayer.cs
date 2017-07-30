using UnityEngine;

public class CameraFindPlayer : MonoBehaviour
{

    void Start()
    {
        transform.position = new Vector3(SunFlower.instance.transform.position.x, SunFlower.instance.transform.position.y, transform.position.z);
    }

}
