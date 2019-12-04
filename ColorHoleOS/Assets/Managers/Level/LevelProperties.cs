using System;
using UnityEngine;

/// <summary>
/// This class contains level data which consists of friendly and obstacle objects transforms.
/// </summary>
[Serializable]
public class LevelProperties
{
    public FriendlyCube[] friendlyCubes; // Container array of friendly game objects to collect.
    public ObstacleCube[] obstacleCubes; // Container array of obstacle game objects to avoid.

    //TODO : Not necessary for now, but can add rotation and scale component of object or directly the transform of it.

    /// <summary>
    /// Friendly cube transforms.
    /// </summary>
    [Serializable]
    public class FriendlyCube
    {
        public Vector3 position = Vector3.zero;

        public FriendlyCube(Vector3 position)
        {
            this.position = position;
        }
    }

    /// <summary>
    /// Obstacle cube transforms.
    /// </summary>
    [Serializable]
    public class ObstacleCube
    {
        public Vector3 position = Vector3.zero;

        public ObstacleCube(Vector3 position)
        {
            this.position = position;
        }
    }
}
