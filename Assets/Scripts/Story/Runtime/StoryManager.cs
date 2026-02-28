using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public StoryLoader loader;
    private StoryContent content;

    public LocationData CurrentLocation { get; private set; }

    void Start()
    {
        content = loader.Load();
        GoToLocation("town");
    }

    public void GoToLocation(string id)
    {
        CurrentLocation = content.locations.FirstOrDefault(loc => loc.id == id);

        StoryUIController.Instance.SetStoryText(CurrentLocation.intro);
        StoryUIController.Instance.SetActions(CurrentLocation.actions);
    }

    public void TriggerEncounter(string encounterId = "defaultEncounter")
    {
        var enc = content.encounters.First(e => e.id == encounterId);

        StoryUIController.Instance.SetStoryText(enc.into);
        StoryUIController.Instance.SetActions(enc.actions);
    }
}