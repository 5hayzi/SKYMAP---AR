using UnityEngine;

public class ARObjectRotation : MonoBehaviour
{
    // Adjust this speed to control the rotation sensitivity
    public float rotationSpeed = 2.0f;

    private bool isRotating = false;
    private Vector2 startTouchPosition;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Check for touch phase
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Record the starting touch position
                    startTouchPosition = touch.position;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        // Calculate the rotation amount based on touch movement
                        float rotationX = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;
                        float rotationY = -touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                        // Apply rotation to the object
                        transform.Rotate(Vector3.right, rotationX);
                        transform.Rotate(Vector3.up, rotationY);
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }
}
