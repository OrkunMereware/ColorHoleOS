using UnityEngine;

public class PoolCollector : MonoBehaviour
{
    [Tooltip("Target pool to return the object.")] [SerializeField]
    private ObjectPool targetPool;

    private void OnTriggerEnter(Collider other)
    {
        targetPool.Reset(other.gameObject);
    }
}
