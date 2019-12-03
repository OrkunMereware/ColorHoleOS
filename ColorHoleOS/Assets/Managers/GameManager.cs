using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 30; // For mobile, make the default value 30 fps.

    void Awake()
    {
        Application.targetFrameRate = targetFrameRate; // Set the application target fps.
    }

}
