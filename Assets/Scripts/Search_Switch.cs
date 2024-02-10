using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Specify the name of the scene to switch to
    public string targetSceneName = "Search_Scene";

    void Start()
    {
        // Attach a method to the button's click event
        // This method will be called when the button is clicked
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }
}
