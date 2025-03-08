using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DungeonEntranceInteraction : MonoBehaviour
{

    public GameObject dungeonDialogueUI;
    public string playerTag = "Player";
    private bool playerNearDungeon = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dungeonDialogueUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearDungeon)
        {
            dungeonDialogueUI.SetActive(true);
        }
        else
        {
            dungeonDialogueUI.SetActive(false);
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
}
