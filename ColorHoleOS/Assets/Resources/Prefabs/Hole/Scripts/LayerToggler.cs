using UnityEngine;

/// <summary>
/// This class detects trigger and changes layer state to make the object fall and be collected later on.
/// </summary>
public class LayerToggler : MonoBehaviour
{
    [Tooltip("Layer ID to switch.")] [SerializeField]
    private int targetLayer = 0;
    //[Tooltip("Default layer ID to switch back.")] [SerializeField]
    //private int defaultLayer = 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">Other game object is generally the Cube object with a collider</param>
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = targetLayer;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("exit");
    //    other.gameObject.layer = defaultLayer;
    //}
}
