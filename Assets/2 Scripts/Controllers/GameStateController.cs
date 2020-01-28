using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateController : StateMachine 
{
	public CameraRig cameraRig;

    [Header("Debugging")]
    public bool haveConversations = true;

	void Start ()
	{
		ChangeState<InitialGameState>();
	}
}