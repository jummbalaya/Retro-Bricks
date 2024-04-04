using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordKeeper : MonoBehaviour
{
    public static RecordKeeper Instance;
    public string highScorePlayerName;
    public int highScore;

    public string currentPlayerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();

    }

    [Serializable]
    public class PlayerData
    {
        public int highScore;
        public string playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }

    public void SavePlayerData(string name, int points)
    {
        SaveData data = new SaveData();

        data.playerName = name;
        data.highScore = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
        Debug.Log("Player data saved.");
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.highScore;

            Debug.Log("PLayer data taken from db.");
        }
    }
}
