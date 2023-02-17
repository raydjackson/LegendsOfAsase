using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using LegendsOfAsaseEnums;

public class SelectAttackOptionState : GameState
{
    public override void Enter()
    {
        PanelManager.instance.switchPanel.SetActive(false);
        PanelManager.instance.techniquePanel.SetActive(false);

        if (PhotonNetwork.IsMasterClient)
        {
            PanelManager.instance.UpdateAttackPanel(FieldManager.instance.p1Playcards[FieldPosition.Active].legend);
        }
        else
        {
            PanelManager.instance.UpdateAttackPanel(FieldManager.instance.p2Playcards[FieldPosition.Active].legend);
        }

        PanelManager.instance.ShowAttackOptionPanel();
        base.Enter();
    }

    public override void Exit()
    {
        PanelManager.instance.HideAttackOptionPanel();
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Attack Option";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        PanelManager.instance.attackElements[0].onClick.AddListener(delegate { AttackWith(PanelManager.instance.attackElementTexts[0].text); });
        if (PanelManager.instance.attackElements[1].gameObject.activeSelf)
        {
            PanelManager.instance.attackElements[1].onClick.AddListener(delegate { AttackWith(PanelManager.instance.attackElementTexts[1].text); });
        }
        PanelManager.instance.attackBackButton.onClick.AddListener(delegate { owner.ChangeState<SelectActionStepState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        PanelManager.instance.attackElements[0].onClick.RemoveAllListeners();
        PanelManager.instance.attackElements[1].onClick.RemoveAllListeners();
        PanelManager.instance.attackBackButton.onClick.RemoveAllListeners();
    }

    public void AttackWith(string elementName)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ActionManager.instance.CreateAction(Constants.ATTACK, elementName, Constants.PLAYER_1);
        }
        else
        {
            ActionManager.instance.CreateAction(Constants.ATTACK, elementName, Constants.PLAYER_2);
        }
        
    }
}
