using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    public float moveSpeed = 1f; // Speed of the player
    public float rotationSpeed = 100f; // Speed of rotation
    bool iscollectkey = false;
    public float destroyDelay = 15.0f; // Delay in seconds before destroying the object
    // Delay in seconds before destroying the key object
    public float spaceshipDelay = 3.0f; // Delay in seconds before showing the "You Win" message
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        // Get player input for forward/backward and left/right movement
        float verticalInput = Input.GetAxis("Vertical"); // W/S or Up/Down keys
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right keys

        // Forward and backward movement
        if (verticalInput != 0)
        {
            animator.SetBool("isWalk", true);
            moveDirection += transform.forward * verticalInput;
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        // Rotate the player left and right
        if (horizontalInput != 0)
        {
            transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        }

        // Apply movement (only change the X and Z positions)
        if (moveDirection != Vector3.zero)
        {
            moveDirection = moveDirection.normalized;
            Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
            newPosition.y = transform.position.y; // Freeze the Y position
            transform.position = newPosition;
        }

        // Float animation example (pressing "f" key)
        if (Input.GetKey("f"))
        {
            animator.SetBool("isFloat", true);
        }
        else
        {
            animator.SetBool("isFloat", false);
        }
    }

    // Detect when the player collides with an object
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Example: Detect collision with a specific object tagged as "Obstacle"
        if (collision.gameObject.CompareTag("OxygenTank"))
        {
            Debug.Log("Player hit oxygen tank!");
            GameData.HealthScore = 100;
            Debug.Log("Health Filled" + GameData.HealthScore);
            // You can add logic here for reducing health, playing a sound, etc.
        }
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject that entered the trigger has the tag "key"
        if (other.CompareTag("key"))
        {
            Debug.Log("Key GameObject entered the trigger.");
            iscollectkey = true;
            // Call the DestroyGameObject method after a delay
            DestroyGameObject();
        }
        if (other.CompareTag("spaceship"))
        {
            if (iscollectkey)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("collect the key");
            }
        }
        if (other.CompareTag("winspaceship"))
        {
            if (iscollectkey)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);

            }
            else
            {
                Debug.Log("collect the key");
            }
        }
    }

    // Method to destroy the GameObject
    private void DestroyGameObject()
    {
        GameObject gameObjectToDestroy = GameObject.FindWithTag("key");
        if (gameObjectToDestroy != null)
        {
            Debug.Log("Destroying GameObject after delay.");
            Destroy(gameObjectToDestroy);
        }
    }






}


