using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InitGameState : GameState
{
    bool gameStarted = false;
    public override void Enter()
    {
        base.Enter();
        NetworkManager.instance.Connect();
    }

    protected override void Update()
    {
        base.Update();
        if (!gameStarted && PhotonNetwork.InRoom)
        {
            //TO DO: move gameStarted bool to GameManager
            gameStarted = true;
            StartCoroutine(Init());
        }
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
