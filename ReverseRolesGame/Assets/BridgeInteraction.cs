using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BridgeInteraction : MonoBehaviour
{

    public GameObject bridgeDialogueUI;
    public string playerTag = "Player";
    private bool playerNearBridge = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bridgeDialogueUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearBridge)
        {
            bridgeDialogueUI.SetActive(true);
        }
        else
        {
            bridgeDialogueUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearBridge = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearBridge = false;
        }
    }
}
