using UnityEngine;

public class EarthCameraAdjuster : MonoBehaviour
{
    // Constants for Earth's axial tilt and radius (in degrees and meters, respectively)
    private const float EarthAxialTilt = 23.5f;
    private const float EarthRadius = 6371000f; // Approximate radius of Earth in meters

    // Reference to the AR camera
    public Camera arCamera;

    void Start()
    {
        // Calculate the Earth's position and rotation based on its axial tilt
        Vector3 earthPosition = CalculateEarthPosition();
        Quaternion earthRotation = CalculateEarthRotation();

        // Adjust the AR camera's position and rotation to match Earth's
        arCamera.transform.position = earthPosition;
        arCamera.transform.rotation = earthRotation;
    }

    Vector3 CalculateEarthPosition()
    {
        // For simplicity, we'll assume Earth is at the origin (0, 0, 0) in Unity world space
        return Vector3.zero;
    }

    Quaternion CalculateEarthRotation()
    {
        // Calculate the rotation based on Earth's axial tilt
        // This rotates the AR camera's forward direction to match Earth's axis of rotation
        return Quaternion.Euler(-EarthAxialTilt, 0, 0);
    }
}
