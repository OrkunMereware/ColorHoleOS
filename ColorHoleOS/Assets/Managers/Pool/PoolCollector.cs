using UnityEngine;
/// <summary>
/// Collect after the relative cubes drop from the hole.
/// </summary>
public class PoolCollector : MonoBehaviour
{
    /// <summary>
    /// Return the relative component to its pool in an deactivated state to be stored for later use, and level ending checks are done here.
    /// </summary>
    /// <param name="other">Generally other component is friendly or obstacle cube.</param>
    private void OnTriggerEnter(Collider other)
    {
        ObjectPool.Reset(other.gameObject); // Return the object clone to its pool and reset transform attributes.
        GameManager.instance.currentCollection++; // Increment current collection count.

        if (GameManager.instance.currentCollection == GameManager.instance.targetCollection)
        {
            GameManager.instance.hole.Center();
        }

    }
}
