using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;
    // Start is called before the first frame update
    public string username;
    public int score;
    
    void Start()
    {
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameAndScore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public int score;
    }
    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            username = data.username;
            score = data.score;
        }
    }

}
