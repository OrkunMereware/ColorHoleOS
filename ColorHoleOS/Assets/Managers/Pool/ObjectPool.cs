using UnityEngine;
/// <summary>
/// A basic object pooling class to pre-instatiate elements for further optimizations.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    [Tooltip("Game object to pre-instantiate.")] [SerializeField]
    private GameObject objectPrefab;
    [Tooltip("Total instances to create.")] [SerializeField]
    private int instanceCount = 0;
    [System.NonSerialized]
    private int currentIndex = -1; // Index counter to return elements to requester class.

    void Awake()
    {
        // Set the name based on the cloned object for convenience.
        transform.name = objectPrefab == null ? "Object Pool [none]" : "Object Pool [" + objectPrefab.name + "]";

        Init();
    }

    private void Init()
    {
        // Instantiate the prefab if it is set from inspector.
        if (objectPrefab != null)
        {
            for (int i = 0; i < instanceCount; i++)
            {
                GameObject prefabClone = MonoBehaviour.Instantiate(objectPrefab); // Instantiate the game object.
                prefabClone.transform.parent = transform; // Set parent to this object pool.
                prefabClone.transform.position = Vector3.zero; // Center object to worldspace.
                prefabClone.SetActive(false); // Deactivate the game object for not calling belonging scripts when unused.
            }
            transform.name = transform.name + " x" + transform.childCount; // Update the name with the clone count for convenience.
        }
    }

    /// <summary>
    /// Finds the appropriate game object clone and returns it.
    /// </summary>
    /// <returns>Returns the next deactivated game object to requested class.</returns>
    public GameObject Get()
    {
        if (currentIndex++ >= transform.childCount)
        {
            currentIndex = 0;
        }
        // TODO : pass to the next deactivated game object if this one is active.
        return transform.GetChild(currentIndex).gameObject;
    }

    /// <summary>
    /// Finds the appropriate game object clone and sets it active then transforms it to the given position.
    /// </summary>
    /// <param name="position">Returns the next deactivated game object in an activated state and sets the world position according to the Vector3 value.</param>
    /// <returns></returns>
    public GameObject SetActiveAtPosition(Vector3 position)
    {
        GameObject clone = Get();
        clone.transform.position = position;
        clone.SetActive(true);
        return clone;
    }

    /// <summary>
    /// Returns the object to the pool by deactivating it.
    /// </summary>
    public static void Return(GameObject clone)
    {
        clone.SetActive(false);
    }

    /// <summary>
    /// Returns the object to the pool by deactivating it and set the world position and rotation to zero.
    /// </summary>
    public static void Reset(GameObject clone)
    {
        Return(clone);
        clone.transform.position = Vector3.zero;
        clone.transform.eulerAngles = Vector3.zero;
    }

}
