using UnityEngine;
using UnityEngine.UI;

public class WaterSlider : MonoBehaviour
{

    void Awake()
    {
        WaterLevel.waterSlider = this.GetComponent<Slider>();
    }
}
