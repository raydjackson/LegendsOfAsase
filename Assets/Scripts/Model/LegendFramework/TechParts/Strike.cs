using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class Strike : TechPart
{
    DamageType strikeDamageType;
    int damage;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate(Legend owner, Legend target, string techOption)
    {
        base.Activate(owner, target, techOption);
        Debug.Log($"{owner.GetShortName()} uses {techOption} {partName} at {target.GetShortName()}");
        //check for Power Mods on owner
        target.GetHealth().PrepareDamage(strikeDamageType, damage);
    }

    public override void ActivateOnConfirm(Legend owner, Legend target, string techOption)
    {
        Activate(owner, target, techOption);
    }

    public void SetDamageParameters(DamageType type, int amount)
    {
        strikeDamageType = type;
        damage = amount;
    }
}
