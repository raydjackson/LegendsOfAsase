using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using LegendsOfAsaseEnums;

public class SelectTechniqueOptionState : GameState
{
    public override void Enter()
    {
        PanelManager.instance.attackPanel.SetActive(false);
        PanelManager.instance.switchPanel.SetActive(false);

        if (PhotonNetwork.IsMasterClient)
        {
            PanelManager.instance.UpdateTechniquePanel(FieldManager.instance.LegendAt(Constants.PLAYER_1, FieldPosition.Active));
        }
        else
        {
            PanelManager.instance.UpdateTechniquePanel(FieldManager.instance.LegendAt(Constants.PLAYER_2, FieldPosition.Active));
        }

        PanelManager.instance.ShowTechniqueOptionPanel();
        base.Enter();
    }

    public override void Exit()
    {
        PanelManager.instance.HideTechniqueOptionPanel();
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Technique Option";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        PanelManager.instance.techniqueOptions[0].onClick.AddListener(delegate { UseTechniqueOption(PanelManager.instance.techniqueOptionTexts[0].text); });
        if (PanelManager.instance.techniqueOptions[1].gameObject.activeSelf)
        {
            PanelManager.instance.techniqueOptions[1].onClick.AddListener(delegate { UseTechniqueOption(PanelManager.instance.techniqueOptionTexts[1].text); });
        }
        PanelManager.instance.techniqueBackButton.onClick.AddListener(delegate { owner.ChangeState<SelectActionStepState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        PanelManager.instance.techniqueOptions[0].onClick.RemoveAllListeners();
        PanelManager.instance.techniqueOptions[1].onClick.RemoveAllListeners();
        PanelManager.instance.techniqueBackButton.onClick.RemoveAllListeners();
    }

    public void UseTechniqueOption(string techniqueOption)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ActionManager.instance.CreateAction(Constants.TECHNIQUE, techniqueOption, Constants.PLAYER_1);
        }
        else
        {
            ActionManager.instance.CreateAction(Constants.TECHNIQUE, techniqueOption, Constants.PLAYER_2);
        }
    }
}
