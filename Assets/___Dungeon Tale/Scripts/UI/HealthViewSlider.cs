using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSlider : MonoBehaviour
{
    /*public PlayerDataSO data;
    void Update()
    {
        GetComponent<Slider>().value = data.health;
    }*/

    public PlayerDataSO data;
    public GameObject HealthPanel;


    void Update()
    {
        HealthPanel.GetComponent<Text>().text = data.health.ToString();
    }
}
