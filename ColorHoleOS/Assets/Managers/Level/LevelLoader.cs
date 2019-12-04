using UnityEngine;
/// <summary>
/// This script loads level from a json file.
/// </summary>
public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// Load game objects based on json values.
    /// </summary>
    /// <param name="jsonStr">Direct json string to process.</param>
    public void Load(string jsonStr, float frontShift)
    {
        LevelProperties level = JsonUtility.FromJson<LevelProperties>(jsonStr);
        GameManager.instance.targetCollection = level.friendlyCubes.Length;
        for (int i = 0; i < level.friendlyCubes.Length; i++)
        {
            GameManager.instance.friendlyPool.SetActiveAtPosition(level.friendlyCubes[i].position + Vector3.forward * frontShift);
        }
        for (int i = 0; i < level.obstacleCubes.Length; i++)
        {
            GameManager.instance.obstaclePool.SetActiveAtPosition(level.obstacleCubes[i].position + Vector3.forward * frontShift);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentLevel">Parse json file according to current level argument.</param>
    public void Load(int currentLevel)
    {
        Load(Resources.Load<TextAsset>("Levels/level_" + currentLevel).text, currentLevel % 2 == 0 ? 0.0f : 140.0f);
    }
}
