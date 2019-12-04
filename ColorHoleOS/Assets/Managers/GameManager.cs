﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Single instance of Game Manager object.
    [Header("Application Settings")]
    [SerializeField] private int targetFrameRate = 30; // For mobile, make the default value 30 fps.
    [Header("Game Settings")]
    [SerializeField] private int currentLevel; // Current level number.
    [Header("Object References")]
    [Tooltip("Hole object reference.")] [SerializeField] public Hole hole;
    [Tooltip("Friendly object pool to retrive items from.")] [SerializeField] public ObjectPool friendlyPool; // Frindly pool reference.
    [Tooltip("Obstacle object pool to retrive items from.")] [SerializeField] public ObjectPool obstaclePool; // Obstacle pool reference.
    [Tooltip("Level loader component.")] [SerializeField] public LevelLoader levelLoader; // Level loader component.
    [Header("Level Variables")]
    [Tooltip("Current level current friendly cube count.")] [SerializeField] public int targetCollection = 0;
    [Tooltip("Current level target friendly cube count.")] [SerializeField] public int currentCollection = 0;


    void Awake()
    {
        instance = this;
        Application.targetFrameRate = targetFrameRate; // Set the application target fps.
    }

    void Start()
    {
        levelLoader.Load(currentLevel);    
    }

}
