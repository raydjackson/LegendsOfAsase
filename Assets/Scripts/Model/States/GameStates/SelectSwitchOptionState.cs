using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SelectSwitchOptionState : GameState
{
    public override void Enter()
    {
        PanelManager.instance.attackPanel.SetActive(false);
        PanelManager.instance.techniquePanel.SetActive(false);
        PanelManager.instance.ShowSwitchOptionPanel();
        base.Enter();
    }

    public override void Exit()
    {
        PanelManager.instance.HideSwitchOptionPanel();
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Switch Option";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        PanelManager.instance.switchLeftButton.onClick.AddListener(delegate { SwitchTo(Constants.SWITCH_LEFT); });
        PanelManager.instance.switchRightButton.onClick.AddListener(delegate { SwitchTo(Constants.SWITCH_RIGHT); });
        PanelManager.instance.switchBackButton.onClick.AddListener(delegate { owner.ChangeState<SelectActionStepState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        PanelManager.instance.switchLeftButton.onClick.RemoveAllListeners();
        PanelManager.instance.switchRightButton.onClick.RemoveAllListeners();
        PanelManager.instance.switchBackButton.onClick.RemoveAllListeners();
    }

    public void SwitchTo(string switchDirection)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ActionManager.instance.CreateAction(Constants.SWITCH, switchDirection, Constants.PLAYER_1);
        }
        else
        {
            ActionManager.instance.CreateAction(Constants.SWITCH, switchDirection, Constants.PLAYER_2);
        }
    }
}
