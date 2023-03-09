using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CreateShield))]
[RequireComponent(typeof(CreatePower))]
public class BulkUp : Technique
{
    public override string[] GetTechOptions()
    {
        string[] opt = { Constants.TECHOPT_NONE };
        return opt;
    }

    public override void Use(int tpIndex, Legend owner, Legend target, string techOption)
    {
        if (tpIndex < techParts.Length)
        {
            techParts[tpIndex].Activate(owner, owner, techOption);
        }
        else
        {
            Debug.Log($"Only {techParts.Length} TechParts found.");
        }
    }

    public override void UseOnConfirm(int tpIndex, Legend owner, Legend target, string techOption)
    {
        //no need for any confirming with this technique
        Use(tpIndex, owner, target, techOption);
    }
}
