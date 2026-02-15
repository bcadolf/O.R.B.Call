using UnityEngine;

public class StoryLoader : MonoBehaviour
{
    public TextAsset storyJson;

    public StoryContent Load()
    {
        return JsonUtility.FromJson<StoryContent>(storyJson.text);
    }
}


