using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DungeonInteraction : MonoBehaviour
{

    public GameObject dungeonDialogueUI;
    public GameObject successDialogueUI;
    public string playerTag = "Player";
    private bool playerNearDungeon = false;

    // Added code
    public GameObject keyActor;
    private bool keyPickedUp = false;
    public GameObject keyIcon;
    public GameObject cellDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dungeonDialogueUI.SetActive(false);
        successDialogueUI.SetActive(false);
        keyIcon.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearDungeon)
        {
            if (keyPickedUp)
            {
                dungeonDialogueUI.SetActive(false);
                successDialogueUI.SetActive(true);
                keyIcon.SetActive(true);

                if (Input.GetKeyDown(KeyCode.K))
                {
                    if (cellDoor != null)
                    {
                        Destroy(cellDoor);
                        successDialogueUI.SetActive(false);
                        keyIcon.SetActive(false);
                    }
                }
            }
            else
            {
                successDialogueUI.SetActive(false);
                dungeonDialogueUI.SetActive(true);
                keyIcon.SetActive(false);
            }
        }
        else
        {
            dungeonDialogueUI.SetActive(false);
            successDialogueUI.SetActive(false);
            keyIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearDungeon = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearDungeon = false;
        }
    }

    public void SetKeyPickedUp()
    {
        keyPickedUp = true;
    }
}
