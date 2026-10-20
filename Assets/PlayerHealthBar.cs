using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider; // Reference to the Slider UI
    public PlayerHealthScript playerHealth; // Reference to the player's health system

    void Start()
    {
        slider.maxValue = 100; // Set slider max value
        slider.value = GameData.HealthScore; // Initialize slider value
    }

    void Update()
    {
        slider.value = GameData.HealthScore ; // Update slider value based on current health
    }
}
