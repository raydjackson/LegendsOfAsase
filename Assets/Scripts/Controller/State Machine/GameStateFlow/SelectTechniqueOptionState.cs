using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTechniqueOptionState : GameState
{
    public override void Enter()
    {
        ActionPanelManager.instance.attackPanel.SetActive(false);
        ActionPanelManager.instance.switchPanel.SetActive(false);
        //Update Technique Panel
        ActionPanelManager.instance.ShowTechniqueOptionPanel();
        base.Enter();
    }

    public override void Exit()
    {
        ActionPanelManager.instance.HideTechniqueOptionPanel();
        base.Exit();
    }

    public override string ToString()
    {
        return "Select Technique Option";
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        ActionPanelManager.instance.techniqueOptions[0].onClick.AddListener(delegate { UseTechniqueOption(ActionPanelManager.instance.techniqueOptionTexts[0].text); });
        if (ActionPanelManager.instance.techniqueOptions[1].gameObject.activeSelf)
        {
            ActionPanelManager.instance.techniqueOptions[1].onClick.AddListener(delegate { UseTechniqueOption(ActionPanelManager.instance.techniqueOptionTexts[1].text); });
        }
        ActionPanelManager.instance.techniqueBackButton.onClick.AddListener(delegate { owner.ChangeState<SelectActionStepState>(); });
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        ActionPanelManager.instance.techniqueOptions[0].onClick.RemoveAllListeners();
        ActionPanelManager.instance.techniqueOptions[1].onClick.RemoveAllListeners();
        ActionPanelManager.instance.techniqueBackButton.onClick.RemoveAllListeners();
    }

    public void UseTechniqueOption(string techniqueOption)
    {
        Debug.Log("Using Technique " + techniqueOption);
    }
}
