using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectActionStepState : GameState
{
    public override void Enter()
    {
        PanelManager.instance.ShowActionPanels();
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
        PanelManager.instance.attackButton.onClick.AddListener(delegate { owner.ChangeState<SelectAttackOptionState>(); });
        PanelManager.instance.switchButton.onClick.AddListener(delegate { owner.ChangeState<SelectSwitchOptionState>(); });
        PanelManager.instance.techniqueButton.onClick.AddListener(delegate { owner.ChangeState<SelectTechniqueOptionState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        PanelManager.instance.attackButton.onClick.RemoveAllListeners();
        PanelManager.instance.switchButton.onClick.RemoveAllListeners();
        PanelManager.instance.techniqueButton.onClick.RemoveAllListeners();
    }
}
