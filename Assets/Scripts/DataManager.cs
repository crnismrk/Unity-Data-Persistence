using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private Data data;
    private string dataFileName = "/data.json";

    public int BestScore
    {
        get { return data.bestScore; }
    }

    public string BestPlayerName
    {
        get { return data.bestPlayerName;  }
    }

    public string PlayerName
    {
        get { return data.playerName; }
        set { data.playerName = value; }
    }

    public string BesetScoreText
    {
        get { return "Best Score : " + data.bestPlayerName + " : " + data.bestScore; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData()
    {
        string dataFilePath = Application.persistentDataPath + dataFileName;
        if (File.Exists(dataFilePath))
        {
            string json = File.ReadAllText(dataFilePath);
            data = JsonUtility.FromJson<Data>(json);
        }
    }

    public void SaveData()
    {
        string dataFilePath = Application.persistentDataPath + dataFileName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(dataFilePath, json);
    }

    public void UpdateBestScore(int score)
    {
        if (data.bestScore < score)
        {
            data.bestScore = score;
            data.bestPlayerName = data.playerName;
        }
        SaveData();
    }

    [System.Serializable]
    class Data
    {
        public string playerName;
        public int bestScore;
        public string bestPlayerName;
    }
}
