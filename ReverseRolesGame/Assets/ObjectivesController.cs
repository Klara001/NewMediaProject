using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectivesController : MonoBehaviour
{

    public TextMeshProUGUI objectivesText;
    private List<string> objectives = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddObjective("Pick up your sword");
        AddObjective("Grab your pack");

    }

    public void AddObjective(string objective)
    {
        objectives.Add(objective);
        UpdateObjectivesUI();
    }

    public void RemoveObjective(string objective)
    {
        if (objectives.Contains(objective))
        {
            objectives.Remove(objective);
            UpdateObjectivesUI();
        }
    }

    void UpdateObjectivesUI()
    {
        objectivesText.text = "";
        foreach (string objective in objectives)
        {
            objectivesText.text += "- " + objective + "\n";
        }

        if (objectives.Count == 0)
        {
            objectivesText.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            objectivesText.transform.parent.gameObject.SetActive(true);
        }
    }

    public bool AreAllObjectivesCompleted()
    {
        return objectives.Count == 0;
        
    }
}
