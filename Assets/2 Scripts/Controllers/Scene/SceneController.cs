using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneController : MonoBehaviour
{
    // *** Individual Scene Logic here ***


    public static event EventHandler<InfoEventArgs<bool>> sceneLoaded;

    [SerializeField] bool active;

    private void Start()
    {
        sceneLoaded(this, new InfoEventArgs<bool>(true));
    }

    public virtual void Enter()
    {
        AddListeners();
        active = true;
        LoadMessage();
    }

    public virtual void LoadMessage()
    {
        Debug.LogError("!!! Loaded the standard Scene script! Not a specific one! Change this out in the inspector!!!");
    }

    public virtual void Exit()
    {
        RemoveListeners();
        active = false;
        sceneLoaded(this, new InfoEventArgs<bool>(false));
    }

    protected virtual void OnDestroy()
    {
        RemoveListeners();
    }

    protected virtual void AddListeners()
    {

    }

    protected virtual void RemoveListeners()
    {

    }


}
