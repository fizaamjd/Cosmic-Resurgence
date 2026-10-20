using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay(40f));

    }
    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
