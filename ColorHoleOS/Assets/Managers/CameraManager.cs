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

    void Awake()
    {
        instance = this; // Get the instance of class.
        startPosition = transform.position; // Set the starting position.
    }

    public void Reset()
    {
        transform.position = startPosition; // Reset the transform.
    }

    public void UpdateStartPosition()
    {
        startPosition = transform.position; // Update the starting position which means reset to the world and move based on that.
    }

    public void LerpPosition(float step)
    {
        transform.position = Vector3.Lerp(startPosition, startPosition + forwardDistance, step); // Lerp to the forward distance manually according to step size passed to the function.
    }

}
