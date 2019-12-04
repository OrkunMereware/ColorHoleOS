using UnityEngine;

/// <summary>
/// This class detects trigger and changes collider enable state to falls to make the object fall.
/// </summary>
public class CollisionToggler : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">Other game object is generally the Cube object with a collider</param>
    private void OnTriggerEnter(Collider other)
    {
        Collider collider = other.GetComponent<Collider>();

        // If the game object does not have any collider attached return directly.
        if (collider == null)
        {
            // If it is null, print an error message
            Debug.LogError("CollisionToggler : " + " 'other' game object has no collider. < probably you should check collision layers >");
            return;
        }
        collider.enabled = false;
    }
}
