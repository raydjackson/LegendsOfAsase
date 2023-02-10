using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameState : GameState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering Init Game State");
        StartCoroutine(Init());
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Init Game State");
    }

    public override string ToString()
    {
        return "Init Game State";
    }

    IEnumerator Init()
    {
        yield return null;
        FieldManager.instance.CreateTestPlaycards();
        ActionPanelManager.instance.ShowActionPanels();
        owner.ChangeState<TestGameState>();
    }
}
