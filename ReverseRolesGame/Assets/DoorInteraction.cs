using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; //added to change scenes

public class DoorInteraction : MonoBehaviour
{

    public GameObject dialogueUI;
    public GameObject adventureReadyUI;
    public string playerTag = "Player";
    public ObjectivesController objectivesController;
    private bool playerNearDoor = false;
    [SerializeField] private string loadLevel; //load new level


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
        adventureReadyUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearDoor)
        {
            if (AreObjectivesCompleted())
            {
                dialogueUI.SetActive(false);
                adventureReadyUI.SetActive(true);

                StartCoroutine(LoadLevelWithDelay(2f));
            }
            else
            {
                dialogueUI.SetActive(true);
                adventureReadyUI.SetActive(false);
            }
        }
        else
        {
            dialogueUI.SetActive(false);
            adventureReadyUI.SetActive(false);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearDoor = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearDoor = false;
        }
    }

    private bool AreObjectivesCompleted()
    {
        return objectivesController.AreAllObjectivesCompleted();

    }

    public void CompleteObjective(string objective)
    {
        objectivesController.RemoveObjective(objective);
    }

    private IEnumerator LoadLevelWithDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(loadLevel);
    }
}
