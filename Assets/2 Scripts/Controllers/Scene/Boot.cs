using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : SceneController
{

    public float autoTransitionTime = 2f;
    public string nextSceneName = "";

    [SerializeField] private float time;

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup > time + autoTransitionTime)
        {
            NextScene();
        }
    }

    public override void LoadMessage()
    {
        Debug.Log("Loaded Boot...");
    }

    public override void Enter()
    {
        base.Enter();
        time = Time.realtimeSinceStartup;
    }

    private void NextScene()
    {
        if(nextSceneName != "")
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        else
            Debug.LogError("No scene inputed!");
    }
}
