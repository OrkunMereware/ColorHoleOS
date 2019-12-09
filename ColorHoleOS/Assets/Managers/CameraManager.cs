using System.Collections;
using UnityEngine;
/// <summary>
/// This class is to manage the camera for shake and forward events.
/// </summary>
public class CameraManager : MonoBehaviour
{
    public static CameraManager instance; // Static instance for static attain to class instance.

    [System.NonSerialized] private Vector3 startPosition; // Starting position of the camera when the object initializes.
    [SerializeField] private Vector3 forwardDistance; // Distance to travel when new level comes up.

    public Vector2 targetRes;
    public float distance = 0.0f;

    private float startShift = 0.0f;
    private float endShift = 0.0f;
    private float forwardShift = 0.0f;


    void Awake()
    {
        instance = this; // Get the instance of class.
        startPosition = transform.position; // Set the starting position.
    }

    void Update()
    {
        // Shift the camera by the frustruma
        transform.position = startPosition + new Vector3(0.0f, 0.0f, forwardShift) + transform.forward * (1f - (targetRes.x / targetRes.y) / ((float)Screen.width / (float)Screen.height)) * distance;
    }

    public void UpdateStartPosition()
    {
        startShift = 0.0f; // Update the starting position which means reset to the world and move based on that.
        endShift = startShift + 140.0f;

    }

    public void LerpPosition(float step)
    {
        //transform.position = Vector3.Lerp(startPosition, startPosition + forwardDistance, step); // Lerp to the forward distance manually according to step size passed to the function.
        forwardShift = Mathf.Lerp(startShift, endShift, step);
    }

}