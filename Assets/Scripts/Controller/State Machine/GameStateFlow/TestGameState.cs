using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestGameState : GameState
{
    public override void Enter()
    {
        base.Enter();
        ActionPanelManager.instance.AddAttackButtonListeners();
        Debug.Log("Entering Test Game State");
    }

    public override void Exit()
    {
        base.Exit();
        ActionPanelManager.instance.RemoveAttackButtonListeners();
        Debug.Log("Exiting Test Game State");
    }

    public override string ToString()
    {
        return "Test Game State";
    }
}
