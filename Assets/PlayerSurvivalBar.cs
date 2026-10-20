using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSurvivalBar : MonoBehaviour
{
    public Slider slider; // Reference to the Slider UI
    void Start()
    {
        slider.maxValue = 100; // Set slider max value
        slider.value = GameData.survivalScore; // Initialize slider value
    }

    void Update()
    {
        slider.value = GameData.survivalScore; // Update slider value based on current health
    }
}
