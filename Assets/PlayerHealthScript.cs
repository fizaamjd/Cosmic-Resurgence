using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{
    Animator animator;
    public float maxHealth;
    public float currentHealth;
    private int lives = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    
    // Reference to the UI Text element
    public Text Timer;
    public float relativeTimeScale = 5.0f; // Adjust this value to change the speed of the timer
    void Start()
    {
        currentHealth = GameData.HealthScore;
        lives = GameData.LivesCount;
        Timer.text = GameData.Timer.ToString();
        Debug.Log("Current Health: " + currentHealth);
        Debug.Log("Current Lives: " + lives);
        Debug.Log("Timer is: " + Timer.text);
    }
    void Update()
    {
        TakeDamage();
        
            if (GameData.Timer > 0)
            {
                // Update the timer based on the relative time scale
                GameData.Timer -= Time.deltaTime * relativeTimeScale;

                // Convert time to minutes and seconds
                int minutes = Mathf.FloorToInt(GameData.Timer / 60F);
                int seconds = Mathf.FloorToInt(GameData.Timer % 60);
                int milliseconds = Mathf.FloorToInt((GameData.Timer % 1) * 1000);

                // Update the timer text
                Timer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            }
            else
            {
                // Time is up, trigger game-over event
                GameData.Timer = 0;
                //GameOver();
            }

    }
    
    public void TakeDamage()
    {
        GameData.HealthScore = GameData.HealthScore - 0.10f;
        if (GameData.HealthScore <= 0)
        {
            GameData.LivesCount--;
            Debug.Log("Lives remaining: " + GameData.LivesCount);

            if (GameData.LivesCount == 2)
            {
                life3.SetActive(false); // Disable the third life indicator
                GameData.HealthScore = GameData.HealthScore + 20;
            }
            if (GameData.LivesCount == 1)
            {
                life2.SetActive(false); // Disable the second life indicator
                GameData.HealthScore = GameData.HealthScore + 20;
            }

            if (GameData.LivesCount > 0)
            {
                GameData.HealthScore = GameData.HealthScore+50;
            }
            else
            {
                life1.SetActive(false);
                Die(); // Trigger game over logic
            }
        }
    }

    private void Die()
    {

        Debug.Log(gameObject.name + " has been destroyed!");
    }

}
