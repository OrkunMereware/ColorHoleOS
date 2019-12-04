using UnityEngine;
/// <summary>
/// This script loads level from a json file.
/// </summary>
public class LevelLoader : MonoBehaviour
{
    [Tooltip("Friendly object pool to retrive items from.")] [SerializeField]
    private ObjectPool friendlyPool;

    [Tooltip("Obstacle object pool to retrive items from.")] [SerializeField]
    private ObjectPool obstaclePool;

    public void Load(string jsonStr)
    {
        LevelProperties level = JsonUtility.FromJson<LevelProperties>(jsonStr);
        for (int i = 0; i < level.friendlyCubes.Length; i++)
        {
            friendlyPool.SetActiveAtPosition(level.friendlyCubes[i].position);
        }
        for (int i = 0; i < level.obstacleCubes.Length; i++)
        {
            obstaclePool.SetActiveAtPosition(level.obstacleCubes[i].position);
        }
    }
}
