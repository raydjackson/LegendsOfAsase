using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GameState : State
{
    protected GameStateMachine owner;

    protected virtual void Awake()
    {
        owner = GetComponent<GameStateMachine>();
    }

    protected virtual void Update()
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected override void AddListeners()
    {
        base.AddListeners();
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
    }
}
