using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [Tooltip("Manual translation speed in stage after level completion.")] [SerializeField]
    private float speed = 1.0f;
    [Tooltip("Swipe multiplier for translation magnitude.")]
    [System.NonSerialized]
    public bool canMove = false;
    [System.NonSerialized]
    private Vector3 startPosition;

    void Update()
    {
        if (canMove) // If can move shift the hole by the amount of the swipe
        {
            if (SwipeController.instance.offset.magnitude == 0.0f)
            {
                startPosition = transform.position; // If swipe amount is zero update the starting position
            }
            else
            {
                Vector3 swipeOffset = SwipeController.instance.offset; // Get the current offset.
                transform.position = startPosition + swipeOffset; // Add the current offset to the current world position to shift the hole the amount of the offset.
                float local_x = Mathf.Clamp(transform.position.x, -14.0f, 14.0f); // Clamp the value so that the hole cannot exceed the stage space horizontally.
                float offset_z = GameManager.instance.currentLevel % 2 == 0 ? 0.0f : 140.0f; // Offset is added bacause stage is shifted if the level number is odd.
                float local_z = Mathf.Clamp(transform.position.z, -31.5f - offset_z, 31.5f + offset_z); // Clamp the value so that the hole cannot exceed the stage space vertically.
                transform.position = new Vector3(local_x, transform.position.y, local_z); // Add the values.
            }
        }
    }

    /// <summary>
    /// When level ends, center the hole to go to the next stage.
    /// </summary>
    public void Center()
    {
        StartCoroutine(CenterRoutine(this.speed));
    }

    public IEnumerator CenterRoutine(float speed)
    {
        this.canMove = false;
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

        GameManager.instance.levelLoader.Load(++GameManager.instance.currentLevel);
        GoToNextLevel();
    }

    /// <summary>
    /// When the hole is centered, move the hole to the next stage.
    /// </summary>
    public void GoToNextLevel()
    {
        StartCoroutine(GoToNextLevelRoutine(this.speed));
    }

    public IEnumerator GoToNextLevelRoutine(float speed)
    {
        CameraManager.instance.UpdateStartPosition();

        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(0.0f, 0.0f, 112.0f);
        float maxMagnitude = (currentPosition - targetPosition).magnitude;
        float mag = (currentPosition - targetPosition).magnitude;
        while (mag > 0.01f)
        {
            mag = (currentPosition - targetPosition).magnitude;
            CameraManager.instance.LerpPosition(Calc.map(mag, maxMagnitude, 0.0f, 0.0f, 1.0f));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed * 20.0f);
            currentPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;
        SwipeController.instance.Reset();
        this.canMove = true;
    }
}
