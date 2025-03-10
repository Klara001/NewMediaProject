using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpKey : MonoBehaviour
{

    public string playerTag = "Player";
    private bool playerNearKey = false;

    public GameObject keyActor;
    public GameObject pickUpIcon;
    public GameObject keyDialogueUI;

    //Added code
    public DungeonInteraction dungeonInteraction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickUpIcon.SetActive(false);
        keyDialogueUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearKey)
        {
            pickUpIcon.SetActive(true);
            keyDialogueUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (keyActor != null)
                {
                    Destroy(keyActor);
                    keyDialogueUI.SetActive(false);
                    pickUpIcon.SetActive(false);

                    if (dungeonInteraction != null)
                    {
                        dungeonInteraction.SetKeyPickedUp();
                    }
                }
            }
        }
        else
        {
            pickUpIcon.SetActive(false);
            keyDialogueUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearKey = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearKey = false;
        }
    }
}
