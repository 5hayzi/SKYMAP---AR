using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private DataManager dataManager;

    // Awake is called before Start
    void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        if (dataManager == null)
        {
            // If DataManager is not found in the scene, create an empty GameObject to hold it
            GameObject dataManagerObject = new GameObject("DataManagerObject");
            dataManager = dataManagerObject.AddComponent<DataManager>();
        }
    }

    // Start is called after Awake
    void Start()
    {
        Debug.Log("Start method called.");
        RecordSceneIndex();
    }

    public void RecordSceneIndex()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (dataManager.counter == 0 || dataManager.sceneIndex[dataManager.counter - 1] != currentSceneIndex)
        {
            dataManager.sceneIndex.Add(currentSceneIndex);
            dataManager.counter++;
            Debug.Log("Scene Recorded. Current Scene Index: " + currentSceneIndex);
            Debug.Log("Total Scene counter: " + dataManager.counter);
            Debug.Log("Total Scene Index: " + dataManager.sceneIndex.Count);
        }
        else
        {
            Debug.Log(currentSceneIndex + " Scene Already Recorded");
        }
    }

    public void LoadNextScene()
    {
        if (dataManager.counter > 0)
        {
            SceneManager.LoadScene(dataManager.sceneIndex[dataManager.counter-2]);
            dataManager.sceneIndex.RemoveAt(dataManager.sceneIndex.Count - 1);
            --dataManager.counter;
        }
        else
        {
            Application.Quit();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleEscapeKeyPress();
        }
    }

    void HandleEscapeKeyPress()
    {
        LoadNextScene();
    }
}