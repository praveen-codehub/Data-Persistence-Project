using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInput; // Input field for entering the player's name
    public TextMeshProUGUI bestScoreText; // Text field to display the highest score
    public string playerName;

    void Start()
    {
        
        bestScoreText.text = "BestScore: " + DataManager.Instance.bestPlayer + " :" + DataManager.Instance.highScore;
        // Load the highest score when the game starts
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.HighScoreDetails();
    }

    public void SetName()
    {
        playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    public void Quit()
    {
        DataManager.Instance.HighScoreDetails();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
