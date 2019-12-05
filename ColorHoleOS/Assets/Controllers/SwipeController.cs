using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static SwipeController instance;
    [SerializeField] private LayerMask layerMask;
    [System.NonSerialized] public bool PRESSING = false;
    [System.NonSerialized] private Vector2 pressStart = Vector3.zero;
    [System.NonSerialized] private Vector2 pressCurrent = Vector3.zero;
    [System.NonSerialized] public Vector2 offset = Vector3.zero;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwipeController.instance.PRESSING = true;
            pressStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SwipeController.instance.PRESSING = false;
        }

        if (SwipeController.instance.PRESSING && GameManager.instance.PLAYING && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                GameManager.instance.hole.transform.position = hit.point;
                Debug.DrawLine(hit.point, transform.position);
            }
            //pressCurrent = Input.mousePosition;

            //offset = pressCurrent - pressStart;
            //offset = new Vector2(offset.x / Screen.width, offset.y / Screen.height);
        }
    }

}
