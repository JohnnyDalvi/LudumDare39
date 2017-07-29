using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSlider : MonoBehaviour {

    void Start()
    {
        WaterLevel.waterSlider = this.GetComponent<Slider>();
    }
}
