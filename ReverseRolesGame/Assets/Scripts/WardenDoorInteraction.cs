using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WardenDoorInteraction : MonoBehaviour
{

    public GameObject wardenDialogueUI;
    public string playerTag = "Player";
    private bool playerNearWarden = false;

    public GameObject wardenActor;
    public GameObject attackIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wardenDialogueUI.SetActive(false);
        attackIcon.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearWarden)
        {
            wardenDialogueUI.SetActive(true);
            attackIcon.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Q))
            {
                if (wardenActor != null)
                {
                    Destroy(wardenActor);
                    wardenDialogueUI.SetActive(false);
                    attackIcon.SetActive(false);
                }
            }

        }
        else
        {
            wardenDialogueUI.SetActive(false);
            attackIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearWarden = true;

        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerNearWarden = false;
        }
    }
}
