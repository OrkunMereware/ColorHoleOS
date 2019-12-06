﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Single instance of Game Manager object.
    [Header("Application Settings")]
    [SerializeField] private int targetFrameRate = 30; // For mobile, make the default value 30 fps.
    [Header("Game Settings")]
    [SerializeField] public int currentLevel; // Current level number.
    [SerializeField] public bool PLAYING = false; // Playing state of the game to mask user touch.
    [Header("Object References")]
    [Tooltip("Hole object reference.")] [SerializeField] public Hole hole;
    [Tooltip("Friendly object pool to retrive items from.")] [SerializeField] public ObjectPool friendlyPool; // Frindly pool reference.
    [Tooltip("Obstacle object pool to retrive items from.")] [SerializeField] public ObjectPool obstaclePool; // Obstacle pool reference.
    [Tooltip("Obstacle object pool to retrive items from.")] [SerializeField] public ObjectPool friendlySpherePool; // Sphere pool reference.
    [Tooltip("Level loader component.")] [SerializeField] public LevelLoader levelLoader; // Level loader component.
    [Header("Level Variables")]
    [Tooltip("Current level current friendly cube count.")] [SerializeField] public int targetCollection = 0; // How many boxes should player needs to collect for stage ending.
    [Tooltip("Current level target friendly cube count.")] [SerializeField] public int currentCollection = 0; // How many boxes player has collected in the current stage.


    void Awake()
    {
        instance = this;
        Application.targetFrameRate = targetFrameRate; // Set the application target fps.
    }

    void Start()
    {
        levelLoader.Load(currentLevel); // Load the level manually.
        PLAYING = true; // Set playin to true.
        hole.canMove = true; // Let hole move with user input.
    }

}
