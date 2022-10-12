using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AppConfig
{
    public string DeviceUsed = "AUTO";
    private static AppConfig inst;
    public static AppConfig Inst
    {
        get
        {
            if (inst == null)
                inst = new AppConfig();
            return inst;
        }
    }

    public void UpdateValuesFromJsonString(string jsonString)
    {
        JsonUtility.FromJsonOverwrite(jsonString, Inst);
    }

    public void UpdateValuesFromJsonFile(string filePath)
    {
        UpdateValuesFromJsonString(System.IO.File.ReadAllText(filePath));
    }

    public void UpdateValuesFromJsonFile()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, Application.productName + ".AppConfig.json");
        UpdateValuesFromJsonFile(path);
    }

    public string ToJsonString()
    {
        return JsonUtility.ToJson(Inst, true);
    }
}