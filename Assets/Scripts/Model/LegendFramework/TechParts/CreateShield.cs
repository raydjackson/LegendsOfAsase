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

    public override void ActivatePart(Legend owner, Legend target, string techOption)
    {
        base.ActivatePart(owner, target, techOption);
        Debug.Log($"{owner.GetShortName()} uses {modAmount} {partName} at {target.GetShortName()}");
        target.AddEquipMod<Shield>(modAmount);
    }

    public override void ActivatePartAfterConfirm(Legend owner, Legend target, string techOption)
    {
        ActivatePart(owner, target, techOption);
    }
}
