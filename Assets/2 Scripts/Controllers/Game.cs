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

    // Components that other objects need to call
    [HideInInspector] public MusicPlayer musicPlayer;
    [HideInInspector] public GameStateController gameStateController;
    [HideInInspector] public static Game instance = null;
    
    // Singleton structure
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

            // Add Components to this gameobject
            musicPlayer = this.gameObject.AddComponent<MusicPlayer>();
            gameStateController = this.gameObject.AddComponent<GameStateController>();
        }
    }    
}