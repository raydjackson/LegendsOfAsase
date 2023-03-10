using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : IAction
{
    public string actionType = Constants.SWITCH;
    public string player;
    public Legend actingLegend;
    public string switchDirection;

    public SwitchAction(string player, string switchDir)
    {
        this.player = player;
        switchDirection = switchDir;
        actingLegend = FieldManager.instance.LegendAt(player, LegendsOfAsaseEnums.FieldPosition.Active);
    }

    public void ExecuteFirst(Legend defendingLegend)
    {
        //This step is reserved exclusively for the Hazards tehnique, Switch will use ExecuteSecond
    }

    public void ExecuteSecond(Legend defendingLegend)
    {
        FieldManager.instance.SwitchLegends(player, switchDirection);
    }

    public string GetActionType()
    {
        return actionType;
    }

    public int GetSpeed()
    {
        return 0;
    }

    public string GetActingLegendName()
    {
        return actingLegend.GetShortName();
    }
}
