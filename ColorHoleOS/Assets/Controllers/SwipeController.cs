using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static SwipeController instance; // Class instance to attain statically.
    [SerializeField] private LayerMask layerMask; // Later mask to control which surface ray will collide with.
    [System.NonSerialized] public bool PRESSING = false; // Press state of the touch for later use.
    [System.NonSerialized] private Vector3 pressStart = Vector3.zero; // Starting position of the touch.
    [System.NonSerialized] private Vector3 pressCurrent = Vector3.zero; // Current position of the touch.
    [System.NonSerialized] public Vector3 offset = Vector3.zero; // How much the touch traveled from the starting position.
    [System.NonSerialized] public RaycastHit hit; // Ray hit information to store.

    void Awake()
    {
        instance = this; // Set the class instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Touch received.
        {
            SwipeController.instance.PRESSING = true;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                pressStart = hit.point; // Set the touch position.
            }
            
        }
        else if (Input.GetMouseButtonUp(0)) // Touch lost
        {
            SwipeController.instance.PRESSING = false;
        }

        if (SwipeController.instance.PRESSING && GameManager.instance.PLAYING && Input.GetMouseButton(0))
        {
            // Get the hit position in world space and update the current press.
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                pressCurrent = hit.point;
                offset = pressCurrent - pressStart; // Calculate the total travel.
            }
        }
    }
    /// <summary>
    /// Reset all of the variables.
    /// </summary>
    public void Reset()
    {
        pressStart = Vector3.zero;
        pressCurrent = Vector3.zero;
        offset = pressCurrent - pressStart;
    }

}
