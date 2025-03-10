using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CampfireInteraction : MonoBehaviour
{

    public GameObject campefireDialogueUI;
    public string playerTag = "Player";
    private bool playerNearFire = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        campefireDialogueUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearFire)
        {
            campefireDialogueUI.SetActive(true);
        }
        else
        {
            campefireDialogueUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearFire = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearFire = false;
        }
    }
}
