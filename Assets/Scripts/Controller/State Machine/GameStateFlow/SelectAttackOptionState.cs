using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAttackOptionState : GameState
{
    public override void Enter()
    {
        ActionPanelManager.instance.switchPanel.SetActive(false);
        ActionPanelManager.instance.techniquePanel.SetActive(false);
        ActionPanelManager.instance.UpdateAttackPanel(FieldManager.instance.p1ActiveLegend);
        ActionPanelManager.instance.ShowAttackOptionPanel();
        base.Enter();
    }

    public override void Exit()
    {
        ActionPanelManager.instance.HideAttackOptionPanel();
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Attack Option";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        ActionPanelManager.instance.attackElements[0].onClick.AddListener(delegate { AttackWith(ActionPanelManager.instance.attackElementTexts[0].text); });
        if (ActionPanelManager.instance.attackElements[1].gameObject.activeSelf)
        {
            ActionPanelManager.instance.attackElements[1].onClick.AddListener(delegate { AttackWith(ActionPanelManager.instance.attackElementTexts[1].text); });
        }
        ActionPanelManager.instance.attackBackButton.onClick.AddListener(delegate { owner.ChangeState<SelectActionStepState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ActionPanelManager.instance.attackElements[0].onClick.RemoveAllListeners();
        ActionPanelManager.instance.attackElements[1].onClick.RemoveAllListeners();
        ActionPanelManager.instance.attackBackButton.onClick.RemoveAllListeners();
    }

    public void AttackWith(string elementName)
    {
        Debug.Log("Attacking with " + elementName);
    }
}
