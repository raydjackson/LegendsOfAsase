using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectState : State
{
    public bool allPlayersReady = false;

    public override void Enter()
    {
        base.Enter();
        NetworkManager.instance.Connect();
    }

    protected override void AddListeners()
    {
        base.AddListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            allPlayersReady = true;
            StartCoroutine(NowConnected());
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
    }

    public override string ToString()
    {
        return "Connect State";
    }

    IEnumerator NowConnected()
    {
        yield return new WaitForSeconds(1);
        GameStateMachine.instance.ChangeState<InitGameState>();
    }
}
