using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class Strike : TechPart
{
    DamageType strikeDamageType;
    int damage;

    public override void ActivatePart(Legend owner, Legend target, string techOption)
    {
        base.ActivatePart(owner, target, techOption);
        Debug.Log($"{owner.GetShortName()} uses {techOption} {partName} at {target.GetShortName()}");
        //check for Power Mods on owner
        target.GetHealth().PrepareDamage(strikeDamageType, damage);
    }

    public override void ActivatePartAfterConfirm(Legend owner, Legend target, string techOption)
    {
        ActivatePart(owner, target, techOption);
    }

    /// <summary>
    /// Configure how the Strike should damage, used by the technique calling this part
    /// </summary>
    /// <param name="type">If not Special, determine using the ElementChart</param>
    /// <param name="amount">If damagetype is special, will be an int greater than 0. Otherwise, usually 0.</param>
    public void SetDamageParameters(DamageType type, int amount)
    {
        strikeDamageType = type;
        damage = amount;
    }
}
