using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : SceneController
{
    public string StartGameScene = "";

    public override void LoadMessage()
    {
        Debug.Log("Loaded Main Menu...");
    }

    public void StartGame()
    {
        if (StartGameScene != "")
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGameScene);
        else
            Debug.LogError("No scene inputed!");
    }
}
