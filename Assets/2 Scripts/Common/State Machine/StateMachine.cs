using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {
	public virtual State CurrentState {
		get { return _currentState; }
		set { Transition (value); }
	}
	[SerializeField] protected State _currentState;
    protected List<State> _currentQueue = new List<State>();
	protected bool _inTransition;
    public bool inTransition { get { return _inTransition; } }

	public virtual T GetState<T> () where T : State {
		T target = GetComponent<T>();
		if (target == null)
			target = gameObject.AddComponent<T>();
		return target;
	}
	
	public virtual void ChangeState<T> () where T : State {
		CurrentState = GetState<T>();
	}

	protected virtual void Transition (State value) {
		if (_currentState == value || _inTransition) {

            if (_currentState != value) {
                _currentQueue.Add(value);
                if (Game.instance.debugStateChanges) Debug.Log("Adding to StateMachine queue");
            }

            return;

        }	

		_inTransition = true;

        StartCoroutine(TransitionToNewState(value));
		
	}

    IEnumerator TransitionToNewState(State value) {
        bool cont = true;

        State nextState = value;

        while (cont) {

            if (Game.instance.debugStateChanges) Debug.Log("Changing state from " + CurrentState + " to " + nextState);

            if (_currentState != nextState) {
                if (_currentState != null)
                    _currentState.Exit();

                _currentState = nextState;

                if (_currentState != null)
                    _currentState.Enter();

                yield return new WaitForEndOfFrame();
            }

            if(_currentQueue.Count >= 1) {
                if(_currentQueue[0] != null) {
                    if (Game.instance.debugStateChanges) Debug.Log("State Machine Looping...");
                    nextState = _currentQueue[0];
                    _currentQueue.Remove(nextState);
                }
            } else {
                cont = false;
            }
        }

        if (Game.instance.debugStateChanges) Debug.Log("Exiting State Machine. Queue at:" + _currentQueue.Count);

        _currentQueue = new List<State>();
        _inTransition = false;
        
    }

}