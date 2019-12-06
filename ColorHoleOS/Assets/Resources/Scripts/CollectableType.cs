using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableType : MonoBehaviour
{
    [SerializeField] public TYPE type; 

    public enum TYPE
    {
        FRIENDLY, OBSTACLE, FRIENDLY_FREE
    }
}
