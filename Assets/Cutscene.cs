using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutScene : MonoBehaviour
{
   // public static CutScene instance; // Singleton instance

    //..............................Singleton Implementation...............................................
    public void Start()
    {
       /* //Debug.Log("Cut Scene Started");
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // Keeps this object persistent across scenes
        //}
        //else
        //{
        //    Destroy(gameObject); // Destroy duplicates
        //}*/

        // Start the coroutine to load the next scene after 49 seconds
       // StartCoroutine(LoadNextSceneAfterDelay(10f));
    }


    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}