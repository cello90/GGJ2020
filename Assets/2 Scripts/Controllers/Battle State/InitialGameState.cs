using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitialGameState : GameState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        AddVictoryCondition();
        yield return null;
        //owner.ChangeState<CutSceneState>();
    }

    void SpawnTestUnits()
    {

    }

    void AddVictoryCondition()
    {

    }
}