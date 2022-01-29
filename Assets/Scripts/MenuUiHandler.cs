using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inputField;
    public Text BestScore;
    void Start()
    {
        SetBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getUsername()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        MainManager1.Instance.username = (string)text;
    }
    void SetBestScore()
    {
        string username = MainManager1.Instance.username;
        int bestScore = MainManager1.Instance.score;
        BestScore.text = $"BestScore {username} : {bestScore}";
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
        getUsername();
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
