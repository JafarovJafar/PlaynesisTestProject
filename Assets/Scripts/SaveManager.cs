using System.IO;
using UnityEngine;

public static class SaveManager
{
    public static void Save(string json)
    {
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public static string Load()
    {
        return File.ReadAllText(Application.persistentDataPath + "/save.json");
    }
}