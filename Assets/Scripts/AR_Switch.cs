using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSwitcher : MonoBehaviour
{
    public string targetSceneName = "Main";

    void Start()
    {

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }
}
