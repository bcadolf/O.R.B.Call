using UnityEngine;
using TMPro;

public class StoryUIController : MonoBehaviour
{
    public static StoryUIController Instance;

    public TextMeshProUGUI storyText;
    public Transform buttonContainer;
    public GameObject buttonPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void SetStoryText( string text)
    {
        storyText.text = text;
    }

    public void SetActions(ActionData[] actions)
    {
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.GameObject);
        }

        foreach(var action in actions)
        {
            var btn = Instantiate(buttonPrefab, buttonContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = action.label;

            btn.GetComponent<buttonContainer>().onClick.AddListener(() =>
            {
                HandleAction(action.id);
            });
        }
    }

    void HandleAction(string actionId)
    {
        var manager = FindObjectOfType<StoryManager>();

        var loc = manager.content.locations.FirstOrDefault(l => l.id == actionId);
        if (loc != null)
        {
            manager.GoToLocation(actionId);
            return;
        } 

        switch (actionId)
        {
            case "hunt":
                manager.TriggerEncounter();
                break;

            case "absorb":
                // absorb code
                break;

            case "flee":
                manager.GoToLocation("basicGrounds");
                break;
        }
    
    
    }
}