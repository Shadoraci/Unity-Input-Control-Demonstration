using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class HealthbarScript : MonoBehaviour
{
    Slider HealthSlider;

    private void Start()
    {
        HealthSlider = GetComponent<Slider>();
        HealthSlider.value = 100; 
    }
    public void SetMaximumHealth(int MaxHP)
    {
        HealthSlider.maxValue = MaxHP;
        HealthSlider.value = MaxHP;
    }
    public void SetHealth(int Health)
    {
        HealthSlider.value = Health;
    }
}
