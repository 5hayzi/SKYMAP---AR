using UnityEngine;
using UnityEngine.UI;

public class CelestialBodyViewer : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject subCanvasPrefab;
    public float subCanvasWidth = 300f; // Adjust the width as needed
    public float subCanvasHeight = 200f; // Adjust the height as needed
    public float backgroundColorAlpha = 0.5f; // Adjust the alpha value for transparency

    void Start()
    {
        // Simulate data for a celestial body
        string celestialBodyInfo = "Sun Info: Distance: 149.6 million km, Size: 1,391,000 km";

        // Create a sub-canvas
        GameObject subCanvasObject = Instantiate(subCanvasPrefab, scrollRect.content);
        RectTransform subCanvasRectTransform = subCanvasObject.GetComponent<RectTransform>();

        // Set size of the sub-canvas
        subCanvasRectTransform.sizeDelta = new Vector2(subCanvasWidth, subCanvasHeight);

        // Set the background color to white with transparency
        subCanvasObject.GetComponent<CanvasRenderer>().SetAlpha(backgroundColorAlpha);
        subCanvasObject.GetComponent<Image>().color = Color.white;

        // Create text box
        Text textBox = subCanvasObject.GetComponentInChildren<Text>();
        if (textBox != null)
        {
            textBox.text = celestialBodyInfo;
            textBox.color = Color.white; // Set text color to white
        }
        else
        {
            Debug.LogError("Text component not found on the sub-canvas prefab!");
        }
    }
}
