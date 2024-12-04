using UnityEngine;
using System.IO;
using TMPro;
//using static DataManager;


public class DataManager : MonoBehaviour
{

    public string currentPlayer;
    public static DataManager Instance;
    public int hiScore;
    public string hiName;

    public TextMeshProUGUI bestScoreText;


    public class SaveData
    {
        public string name;
        public int score;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Awake()
    {
        //filepath = Path.Combine(Application.dataPath, "scores.json");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = hiName;
        data.score = hiScore;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
       string json = File.ReadAllText(path);
       SaveData data = JsonUtility.FromJson<SaveData>(json);
       hiName = data.name;
       hiScore = data.score;
       updateScoreInMenuScene();

    }

    public void updateScoreInMenuScene()
    {
        bestScoreText.text = "Best Score: " + hiScore + "   Name: " + hiName;
    }



}
