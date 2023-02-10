using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectActionStepState : GameState
{
    public override void Enter()
    {
        ActionPanelManager.instance.ShowActionPanels();
        base.Enter();
    }

    public override void Exit()
    {
        ActionPanelManager.instance.switchPanel.SetActive(false);
        ActionPanelManager.instance.techniquePanel.SetActive(false);
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Action Step";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        ActionPanelManager.instance.attackButton.onClick.AddListener(delegate { owner.ChangeState<SelectAttackOptionState>(); });
        //switch button
        //technique button
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ActionPanelManager.instance.attackButton.onClick.RemoveAllListeners();
        //switch button
        //technique button
    }
}
