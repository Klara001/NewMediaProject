using UnityEngine;

public class LetterInteraction : MonoBehaviour
{

    public GameObject letter;
    public GameObject letterUI;
    public GameObject letterPickUpIcon;
    public GameObject doorInteraction;
    public GameObject objectivesUI;
    public GameObject player;
    public MonoBehaviour playerControllerScript;

    private bool isPlayerNear = false;
    private bool isUIOpen = false;
    private bool isLetterPickedUp = false;
    
    private void Start()
    {
        doorInteraction.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !isLetterPickedUp)
        {
            OpenLetterUI();
        }
        else if (isLetterPickedUp && isUIOpen && Input.GetKeyDown(KeyCode.E))
        {
            CloseLetterUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            letterPickUpIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (!isLetterPickedUp)
            {
                letterPickUpIcon.SetActive(false);
            }
        }
    }

    private void OpenLetterUI()
    {
        letterUI.SetActive(true);
        isUIOpen = true;
        isLetterPickedUp = true;
        letterPickUpIcon.SetActive(false);

        if (playerControllerScript != null)
        {
            playerControllerScript.enabled = false;
        }
    }

    private void CloseLetterUI()
    {
        letterUI.SetActive(false);
        isUIOpen = false;

        isLetterPickedUp = false;
        letterPickUpIcon.SetActive(true);

        if (playerControllerScript != null)
        {
            playerControllerScript.enabled = true;
        }

        if (objectivesUI != null)
        {
            objectivesUI.SetActive(true);
        }

        if (doorInteraction != null)
        {
            doorInteraction.SetActive(true);
        }
    }
}
