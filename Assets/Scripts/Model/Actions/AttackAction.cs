using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class AttackAction : IAction
{
    public string actionType = Constants.ATTACK;
    public Legend attackingLegend;
    public Element attackElement;

    public AttackAction(Legend legend, Element element)
    {
        attackingLegend = legend;
        attackElement = element;
    }

    public void ExecuteFirst(Legend defendingLegend)
    {
        DamageType attackDamageType = ElementChart.instance.DetermineWeaknessAndResistance(attackElement, defendingLegend);
        int modBonus = 0; //once implemented, check if attackingLegend has any power mods
        defendingLegend.GetHealth().PrepareDamage(attackDamageType, modBonus);
    }

    public void ExecuteSecond(Legend defendingLegend)
    {
        //not used with an Attack action
    }

    public string GetActionType()
    {
        return actionType;
    }
}
