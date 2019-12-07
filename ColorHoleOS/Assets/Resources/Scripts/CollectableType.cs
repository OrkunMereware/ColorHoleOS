using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableType : MonoBehaviour
{
    [SerializeField] public TYPE type; // Type of the object to check end game and win game states.

    public enum TYPE
    {
        FRIENDLY, OBSTACLE, FRIENDLY_FREE
    }
}
