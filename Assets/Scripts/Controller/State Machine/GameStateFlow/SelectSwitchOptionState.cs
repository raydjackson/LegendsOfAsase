using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSwitchOptionState : GameState
{
    public override void Enter()
    {
        ActionPanelManager.instance.attackPanel.SetActive(false);
        ActionPanelManager.instance.techniquePanel.SetActive(false);
        ActionPanelManager.instance.ShowSwitchOptionPanel();
        base.Enter();
    }

    public override void Exit()
    {
        ActionPanelManager.instance.HideSwitchOptionPanel();
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Switch Option";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        ActionPanelManager.instance.switchLeftButton.onClick.AddListener(delegate { SwitchTo("Left"); });
        ActionPanelManager.instance.switchRightButton.onClick.AddListener(delegate { SwitchTo("Right"); });
        ActionPanelManager.instance.switchBackButton.onClick.AddListener(delegate { owner.ChangeState<SelectActionStepState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ActionPanelManager.instance.switchLeftButton.onClick.RemoveAllListeners();
        ActionPanelManager.instance.switchRightButton.onClick.RemoveAllListeners();
        ActionPanelManager.instance.switchBackButton.onClick.RemoveAllListeners();
    }

    public void SwitchTo(string switchDirection)
    {
        Debug.Log("Switching to the " + switchDirection);
    }
}
