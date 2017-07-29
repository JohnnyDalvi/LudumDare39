using UnityEngine;

public class LosePanel : MonoBehaviour
{

    void Start()
    {
        GameController.LosePanel = this.gameObject;
        gameObject.SetActive(false);
    }

}