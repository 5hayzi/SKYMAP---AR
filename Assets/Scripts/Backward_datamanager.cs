using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public List<int> sceneIndex = new List<int>();
    public int counter = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
