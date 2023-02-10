using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameState : GameState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override string ToString()
    {
        return "Init Game State";
    }

    IEnumerator Init()
    {
        yield return null;
        FieldManager.instance.CreateTestPlaycards();
        owner.ChangeState<SelectActionStepState>();
    }
}
