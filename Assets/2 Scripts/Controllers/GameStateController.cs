using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateController : StateMachine 
{
	void Start ()
	{
		ChangeState<InitialGameState>();
	}
}