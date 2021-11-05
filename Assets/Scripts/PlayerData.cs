using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public Text inputName;

    public string playerName;
    public int score;
    public  int bestScore;
    public string bestName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string name;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.score = this.score;
        data.name = this.playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.bestName = data.name;
            this.bestScore = data.score;
        }
        
    }
}
