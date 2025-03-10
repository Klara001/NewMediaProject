using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DungeonEntranceInteraction : MonoBehaviour
{

    public GameObject dungeonDialogueUI;
    public string playerTag = "Player";
    private bool playerNearDungeon = false;
    [SerializeField] private string loadLevel; //load new level

    //Added code
    public GameObject dungeonActor;
    public GameObject aIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dungeonDialogueUI.SetActive(false);

        //Added code
        aIcon.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerNearDungeon)
        {
            dungeonDialogueUI.SetActive(true);

            aIcon.SetActive(true);

            //Added code
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (dungeonActor != null)
                {
                    Destroy(dungeonActor);

                    dungeonDialogueUI.SetActive(false);

                    aIcon.SetActive(false);

                    SceneManager.LoadScene(loadLevel);
                }
            }
        }
        else
        {
            dungeonDialogueUI.SetActive(false);

            //Added code
            aIcon.SetActive(false);
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
