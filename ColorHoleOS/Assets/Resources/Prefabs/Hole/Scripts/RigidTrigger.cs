using UnityEngine;

/// <summary>
/// This class detects trigger and applies force in the direction of the trigger position.
/// </summary>

public class RigidTrigger : MonoBehaviour
{
    [Tooltip("The amplitude of the applied force on the trigger object to scale it through inspector.")]
    [SerializeField]
    private float magnitude = 100.0f;
    [Tooltip("The amplitude of the applied force on the trigger object relative to the height value.")]
    [SerializeField]
    private float altitudeMagnitude = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">Other game object is generally the Cube object which has a kinematic rigidbody</param>
    private void OnTriggerEnter(Collider other)
    {
        CollectableType.TYPE type = other.GetComponent<CollectableType>().type;

        if (GameManager.instance.hole.canMove || type.Equals(CollectableType.TYPE.FRIENDLY_FREE))
        {
            Rigidbody rigidBody = other.GetComponent<Rigidbody>(); // Get the rigidbody component.

            // If the game object does not have any rigidbody attached return directly.
            if (rigidBody == null)
            {
                // If it is null, print an error message
                Debug.LogError("RigidTrigger : " + " 'other' game object has no rigidbody. < probably you should check collision layers >");
                return;
            }

            rigidBody.isKinematic = false; // Set the body to dynamic, so it can fall.
            float altitudeForce = transform.position.y * altitudeMagnitude; // Force is applied greater with altitude so it can fall to the hole better.
            Vector3 fallDirection = (transform.position - rigidBody.transform.position).normalized; // This is the normalized direction vector from the Cube to the Hole.
            rigidBody.AddForce(fallDirection * magnitude * altitudeForce);
        }
    }

}
