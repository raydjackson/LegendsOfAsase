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
        ActionPanelManager.instance.switchButton.onClick.AddListener(delegate { owner.ChangeState<SelectSwitchOptionState>(); });
        ActionPanelManager.instance.techniqueButton.onClick.AddListener(delegate { owner.ChangeState<SelectTechniqueOptionState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ActionPanelManager.instance.attackButton.onClick.RemoveAllListeners();
        ActionPanelManager.instance.switchButton.onClick.RemoveAllListeners();
        ActionPanelManager.instance.techniqueButton.onClick.RemoveAllListeners();
    }
}
