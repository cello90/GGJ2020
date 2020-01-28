using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Debugging")]
    public bool debugStateChanges = false;
    public bool debugNotificationCenter = false;
    public bool debugLogBoot = false;
    public bool playMusic = true;

    public static Game instance = null;

    [Header("Components")]
    MusicPlayer musicPlayer;

    void OnEnable()
    {
        if(instance != null && this != instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            // Gather Components
            musicPlayer = GetComponent<MusicPlayer>();
        }
    }

    public GameStateController gameStateController;
    public bool inTransition
    {
        get
        {
            if(gameStateController != null)
            {
                return gameStateController.inTransition;
            }
            else
            {
                return false;
            }
        }
    }


}