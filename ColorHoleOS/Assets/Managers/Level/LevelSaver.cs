using System.IO;
using UnityEngine;

[ExecuteInEditMode] // Save the level to json file without running the application in edit mode.
public class LevelSaver : MonoBehaviour
{
    [Tooltip("Level number.")] [SerializeField]
    private int levelNumber = 0;
    [Tooltip("Friendly cube parent object.")] [SerializeField]
    private GameObject friendlyCubesParent;
    [Tooltip("Obstacle cube parent object.")] [SerializeField]
    private GameObject obstacleCubesParent;
    [Tooltip("Path to save levels.")] [SerializeField]
    private string path;

    public void Save()
    {
        LevelProperties levelProperties = new LevelProperties(); // Create a local levelProperty object to convert json data.

        levelProperties.friendlyCubes = new LevelProperties.FriendlyCube[friendlyCubesParent.transform.childCount]; // Create local space for objects array.
        for (int i = 0; i < levelProperties.friendlyCubes.Length; i++)
        {
            levelProperties.friendlyCubes[i] = new LevelProperties.FriendlyCube(friendlyCubesParent.transform.GetChild(i).position); // Store the location information of friendly cube.
        }

        levelProperties.obstacleCubes = new LevelProperties.ObstacleCube[obstacleCubesParent.transform.childCount];
        for (int i = 0; i < levelProperties.obstacleCubes.Length; i++)
        {
            levelProperties.obstacleCubes[i] = new LevelProperties.ObstacleCube(obstacleCubesParent.transform.GetChild(i).position); // Store the location information of obstacle cube.
        }

        string jsonStr = JsonUtility.ToJson(levelProperties, true); // Convert class to json string.

        File.WriteAllText(path + "/level_" + levelNumber + ".json", jsonStr); // Store json string in a json file. Renamed according to level number.
    }

}
