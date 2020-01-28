using UnityEngine;
using System.Collections;

public abstract class BaseVictoryCondition : MonoBehaviour
{
    #region Fields & Properties
    GameStateController bc;
	#endregion
	
	#region MonoBehaviour
	protected virtual void Awake ()
	{
		bc = GetComponent<GameStateController>();
	}
	
	protected virtual void OnEnable ()
	{
		//this.AddObserver(OnHPDidChangeNotification, Stats.DidChangeNotification(StatTypes.HP));
	}
	
	protected virtual void OnDisable ()
	{
		//this.RemoveObserver(OnHPDidChangeNotification, Stats.DidChangeNotification(StatTypes.HP));
	}
	#endregion
	
	#region Notification Handlers
	protected virtual void OnHPDidChangeNotification (object sender, object args)
	{
		CheckForGameOver();
	}
	#endregion
	
	#region Protected
	protected virtual void CheckForGameOver() { 
		
	}
	#endregion
}