using UnityEngine;
using System.IO;



public static class DeletePlayerCharacter
{
    private static string savePath = Application.persistentDataPath + "/savedPlayerCharacters.json";

    public static void Delete()
    {
        File.Delete(savePath);
    }
}

