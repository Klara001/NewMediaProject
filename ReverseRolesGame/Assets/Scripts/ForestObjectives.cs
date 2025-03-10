using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ForestObjectives : MonoBehaviour
{

    public TextMeshProUGUI forestObjectivesText;
    private List<string> forestObjectives = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddObjective("Find out where the Lord has been taken.");
    }

    public void AddObjective(string objective)
    {
        forestObjectives.Add(objective);
        UpdateObjectivesUI();
    }

    public void RemoveObjective(string objective)
    {
        if (forestObjectives.Contains(objective))
        {
            forestObjectives.Remove(objective);
            UpdateObjectivesUI();
        }
    }

    void UpdateObjectivesUI()
    {
        forestObjectivesText.text = "";
        foreach (string objective in forestObjectives)
        {
            forestObjectivesText.text += "- " + objective + "\n";
        }

        if (forestObjectives.Count == 0)
        {
            forestObjectivesText.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            forestObjectivesText.transform.parent.gameObject.SetActive(true);
        }
    }

    public bool AreAllObjectivesCompleted()
    {
        return forestObjectives.Count == 0;
        
    }
}