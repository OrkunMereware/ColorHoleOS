using UnityEngine;

/// <summary>
/// This class detects trigger and changes layer state to make the object fall and be collected later on.
/// </summary>
public class LayerToggler : MonoBehaviour
{
    [Tooltip("Layer ID to switch.")] [SerializeField]
    private int targetLayer = 0;
    [Tooltip("Default layer ID to switch back.")][SerializeField]
    private int defaultLayer = 8;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">Other game object is generally the Cube object with a collider</param>
    private void OnTriggerEnter(Collider other)
    {
        // Change layer to collect the game object.
        if (!(other.gameObject.layer == 11 && (GameManager.instance.hole.transform.position - other.transform.position).magnitude > 3.0f))
        {
            //Debug.Log("collect " + 8);
            other.gameObject.layer = 11;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Change layer to collide when hole is further away.
        if (other.gameObject.layer == 11 && (GameManager.instance.hole.transform.position - other.transform.position).magnitude > 3.0f)
        {
            other.gameObject.layer = 8;
        }
    }

}
