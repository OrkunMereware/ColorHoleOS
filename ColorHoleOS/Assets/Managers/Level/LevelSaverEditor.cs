using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelSaver))]
public class LevelSaverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelSaver levelSaverScript = (LevelSaver)target;
        if (GUILayout.Button("Save"))
        {
            levelSaverScript.Save();
        }
    }
}