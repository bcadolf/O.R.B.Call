using UnityEngine;
using System.IO;

public static class SavePlayerCharacter
{
    private static string savePath = Application.persistentDataPath + "/savedPlayerCharaters.json";

    public static void Save(CharacterRuntime character)
    {
        string json = JsonUtility.ToJson(character, true);
        File.WriteAllText(savePath, json);
    }

    public static CharacterRuntime Load()
    {
        if (!File.Exists(savePath))
        {
            return null;
        }

        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<CharacterRuntime>(json);
    }
}