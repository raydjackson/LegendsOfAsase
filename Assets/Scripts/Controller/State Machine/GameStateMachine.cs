using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    public static GameStateMachine instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeState<ConnectState>();
    }
}
