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

    // Singleton Structure Code
    [HideInInspector] public static Game instance = null;

    // Components that other objects need to call -> Create all OnEnable
    [HideInInspector] public MusicPlayer musicPlayer;
    [HideInInspector] public GameStateController gameStateController;
    [HideInInspector] public InputController inputController;
    [HideInInspector] public RaycastController raycastController;

    // Control how the scene functions
    [HideInInspector] public SceneController currentSceneController;

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
            inputController = this.gameObject.AddComponent<InputController>();
            raycastController = this.gameObject.AddComponent<RaycastController>();

            // Subscribe to Events
            SceneController.sceneLoaded += OnSceneLoad;
        }
    }    

    void OnSceneLoad(object obj, InfoEventArgs<bool> e)
    {
        currentSceneController = obj as SceneController;
        currentSceneController.Enter();
    }

    // Unsubscribe to events --- SHOULD NOT HAPPEN
    private void OnDestroy()
    {
        SceneController.sceneLoaded -= OnSceneLoad;
    }
}