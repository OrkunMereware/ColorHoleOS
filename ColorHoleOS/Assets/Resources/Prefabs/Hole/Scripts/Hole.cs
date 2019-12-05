using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [Tooltip("Manual translation speed in stage after level completion.")] [SerializeField]
    private float speed = 1.0f;
    [Tooltip("Swipe multiplier for translation magnitude.")]
    [SerializeField]
    private float swipeMultiplier = 1.0f;
    [System.NonSerialized]
    public bool canMove = false;
    //[System.NonSerialized]
    //private Vector3 startPosition;

    void Update()
    {
        //if (canMove)
        //{
        //    if (SwipeController.instance.offset.magnitude == 0.0f)
        //    {
        //        startPosition = transform.position;
        //    }
        //    else
        //    {
        //        Vector2 swipeOffset = SwipeController.instance.offset * swipeMultiplier;
        //        transform.position = startPosition + new Vector3(swipeOffset.x, 0.0f, swipeOffset.y);
        //    }
        //}
    }

    public void Center()
    {
        StartCoroutine(CenterRoutine(this.speed));
    }

    public IEnumerator CenterRoutine(float speed)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(0.0f, startPosition.y, startPosition.z);
        float timeStep = 0.0f;
        while (timeStep < 1.0f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeStep);
            timeStep += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;

        GoToNextLevel();
    }

    public void GoToNextLevel()
    {
        StartCoroutine(GoToNextLevelRoutine(this.speed));
    }

    public IEnumerator GoToNextLevelRoutine(float speed)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(0.0f, 0.0f, 112.0f);
        while ((currentPosition - targetPosition).magnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed * 20.0f);
            currentPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;
    }
}
