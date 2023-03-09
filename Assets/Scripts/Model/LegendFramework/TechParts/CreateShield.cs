using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShield : TechPart
{
    public int modAmount;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate(Legend owner, Legend target, string techOption)
    {
        base.Activate(owner, target, techOption);
        Debug.Log($"{owner.GetShortName()} uses {modAmount} {partName} at {target.GetShortName()}");
        target.AddEquipMod<Shield>(modAmount);
    }

    public override void ActivateOnConfirm(Legend owner, Legend target, string techOption)
    {
        Activate(owner, target, techOption);
    }
}
