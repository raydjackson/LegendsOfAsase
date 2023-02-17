using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PanelManager.instance.switchLeftButton.onClick.AddListener(delegate { SwitchTo("Left"); });
        PanelManager.instance.switchRightButton.onClick.AddListener(delegate { SwitchTo("Right"); });
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
        Debug.Log("Switching to the " + switchDirection);
    }
}
