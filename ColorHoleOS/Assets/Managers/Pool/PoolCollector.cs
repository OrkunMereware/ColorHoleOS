using UnityEngine;
/// <summary>
/// Collect after the relative cubes drop from the hole.
/// </summary>
public class PoolCollector : MonoBehaviour
{
    /// <summary>
    /// Return the relative component to its pool in an deactivated state to be stored for later use, and level ending checks are done here.
    /// </summary>
    /// <param name="other">Generally other component is friendly or obstacle cube.</param>
    private void OnTriggerEnter(Collider other)
    {
        CollectableType.TYPE type = other.GetComponent<CollectableType>().type;
        if (GameManager.instance.hole.canMove || type.Equals(CollectableType.TYPE.FRIENDLY_FREE))
        {
            ObjectPool.Reset(other.gameObject); // Return the object clone to its pool and reset transform attributes.
            if (type.Equals(CollectableType.TYPE.FRIENDLY))
            {
                GameManager.instance.currentCollection++; // Increment current collection count.
                GameManager.instance.SetLevelIndicatorText((int)Calc.map(GameManager.instance.currentCollection, 0.0f, GameManager.instance.targetCollection, 0.0f, 100.0f));
                if (GameManager.instance.currentCollection == GameManager.instance.targetCollection)
                {
                    if (GameManager.instance.currentLevel % 2 == 0)
                    {
                        GameManager.instance.hole.Center();
                    }
                    else
                    {
                        GameManager.instance.levelIndicatorText.SetText("You Win!");
                        GameManager.instance.levelLoader.Load(++GameManager.instance.currentLevel);
                    }
                }
            } else if (type.Equals(CollectableType.TYPE.OBSTACLE))
            {
                GameManager.instance.GameOver();
            }

        }

    }
}
