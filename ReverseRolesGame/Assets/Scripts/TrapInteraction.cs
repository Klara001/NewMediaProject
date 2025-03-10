using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapInteraction : MonoBehaviour
{

    public GameObject theDialogueUI;
    public string playerTag = "Player";
    private bool playerNearTrap = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theDialogueUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearTrap)
        {
            theDialogueUI.SetActive(true);
        }
        else
        {
            theDialogueUI.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearTrap = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearTrap = false;
        }
    }
}
