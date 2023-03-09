using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechniqueAction : IAction
{
    public string actionType = Constants.TECHNIQUE;
    public Legend actingLegend;
    public string techniqueOption;

    public TechniqueAction(Legend actingleg, string techniqueOption)
    {
        actingLegend = actingleg;
        this.techniqueOption = techniqueOption;
    }

    public void ExecuteFirst(Legend defendingLegend)
    {
        actingLegend.legendTech.Use(0, actingLegend, defendingLegend, techniqueOption);
    }

    public void ExecuteSecond(Legend defendingLegend)
    {
        actingLegend.legendTech.Use(1, actingLegend, defendingLegend, techniqueOption);
    }

    public string GetActionType()
    {
        return actionType;
    }
}
