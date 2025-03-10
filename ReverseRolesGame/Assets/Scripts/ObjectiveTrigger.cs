using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{

    public string objectiveToComplete;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ObjectivesController>().RemoveObjective(objectiveToComplete);
            Destroy(gameObject);
        }
    }
}
