using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A basic script for the gate prefab for openening to indicate that the next level is coming.
/// </summary>
public class Gate : MonoBehaviour
{
    [SerializeField] private AnimationCurve upCurve; // Animation curve to evalute the vertical distance to make the game object to translate.
    [SerializeField] private float speed; // Translation speed.
    [SerializeField] private float magnitude; // Translation speed.
    [System.NonSerialized] private Vector3 startPosition; // Start position of the gate.

    void Awake()
    {
        startPosition = transform.localPosition;    
    }

    public void OpenStep(float timeStep)
    {
        transform.localPosition = startPosition + Vector3.down * upCurve.Evaluate(timeStep) * magnitude; // Translate the gate downwards
    }
}
