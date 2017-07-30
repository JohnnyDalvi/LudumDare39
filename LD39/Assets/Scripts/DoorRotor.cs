using System.Collections;
using UnityEngine;

public class DoorRotor : MonoBehaviour
{

    public float maximumAngle;
    public float rotationSpeed;
    Quaternion initialRotation;
    public Transform axis;
    public float closingTimer;
    bool isClosing;
    bool isOpening;
    public bool isLeftSided;

    void Start()
    {
        initialRotation = axis.localRotation;
    }


    void FixedUpdate()
    {
        if (isOpening)
            OpeningDoor();
        else if (isClosing)
            ClosingDoor();
    }

    public IEnumerator CloseDoorEnum()
    {
        isOpening = false;
        yield return new WaitForSeconds(closingTimer);
        isClosing = true;
    }

    public void OpenDoor()
    {
        isOpening = true;
    }

    void OpeningDoor()
    {
        if (Quaternion.Angle(axis.rotation, initialRotation) <= maximumAngle)
        {
            if (!isLeftSided)
                axis.Rotate(Vector3.forward, rotationSpeed);
            else
                axis.Rotate(Vector3.back, rotationSpeed);
        }
    }

    void ClosingDoor()
    {
        if (Quaternion.Angle(axis.rotation, initialRotation) >= 2)
        {
            if (!isLeftSided)
                axis.Rotate(Vector3.back, rotationSpeed);
            else
                axis.Rotate(Vector3.forward, rotationSpeed);
        }
        else
        {
            isClosing = false;
        }
    }
}
