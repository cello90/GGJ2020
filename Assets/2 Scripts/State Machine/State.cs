using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {
    [SerializeField] bool active;
    public virtual void Enter() {
        AddListeners();
        active = true;
    }

    public virtual void Exit() {
        RemoveListeners();
        active = false;
    }

    protected virtual void OnDestroy() {
        RemoveListeners();
    }

    protected virtual void AddListeners() {

    }

    protected virtual void RemoveListeners() {

    }
}