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
    public int Load(string jsonStr, float frontShift)
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
        return level.friendlyCubes.Length;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentLevel">Parse json file according to current level argument.</param>
    public void Load(int currentLevel)
    {
        if (currentLevel % 2 == 0)
        {
            PlaceFriendlySpheres();
        }
        GameManager.instance.currentCollection = 0;
        GameManager.instance.targetCollection = Load(Resources.Load<TextAsset>("Levels/level_" + currentLevel).text, currentLevel % 2 == 0 ? 0.0f : 140.0f);
        GameManager.instance.SetLevelIndicatorText(0);
    }

    /// <summary>
    /// Place friendly sphere game objects.
    /// </summary>
    private void PlaceFriendlySpheres()
    {
        Vector3 offset = new Vector3(-2.1f, 1.25f, 38.0f); // shift friendly sphere game objects to the middle position.
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                GameManager.instance.friendlySpherePool.SetActiveAtPosition(new Vector3(1.1f * i, 0.0f, 1.1f * j) + offset); // set the pool clone game object transform and activate it.
            }
        }
    }
}
