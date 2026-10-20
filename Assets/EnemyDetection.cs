using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetection : MonoBehaviour
{
    public AudioClip alertclip;
    private AudioSource alertSound;  // Reference to the AudioSource component
    public Transform player;         // Reference to the player's Transform
    public float rotationSpeed = 10f;  // Speed of rotation
    public float stopDistance = 0.1f;  // Distance to stop before reaching the player

    private bool playerInRange = false;
    private AlienMovement alienMovement;

    void Start()
    {
        
        alertSound = gameObject.AddComponent<AudioSource>();
        alienMovement = GetComponent<AlienMovement>();

        // Add a null check for alienMovement
        if (alienMovement == null)
        {
            Debug.LogError("AlienMovement component not found on the GameObject.");
        }
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            alertSound.PlayOneShot(alertclip);
            playerInRange = true;
            GameData.survivalScore = GameData.survivalScore - 1;
            // Check if survivalScore is 0 and load the next scene
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (alienMovement != null)
            {
                alienMovement.StopMovingToPlayer();  // Stop moving towards the player
            }
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            if (alienMovement != null)
            {
                alienMovement.MoveTo(player.position);
            }
        }
    }
}
