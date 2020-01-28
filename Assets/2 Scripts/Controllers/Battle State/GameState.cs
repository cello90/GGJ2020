using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GameState : State {
    protected GameStateController owner;

    public CameraRig cameraRig { get { return owner.cameraRig; } }

    protected virtual void Awake() {
        owner = GetComponent<GameStateController>();
    }

    protected override void AddListeners() {
        //InputController.moveEvent += OnMove;
        //InputController.fireEvent += OnFire;
    }

    protected override void RemoveListeners() {
        //InputController.moveEvent -= OnMove;
        //InputController.fireEvent -= OnFire;
    }

    public override void Enter() {
        base.Enter();
    }

    protected virtual void OnMove(object sender, InfoEventArgs<Vector2> e) {

    }

    protected virtual void OnFire(object sender, InfoEventArgs<int> e) {

    }
}