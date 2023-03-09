using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

[RequireComponent(typeof(Strike))]
public class CripplingStrike : Technique
{
    [SerializeField]
    DamageType techDamageType;
    [SerializeField]
    int maxDamage;
    [SerializeField]
    int minDamage;

    public override string[] GetTechOptions()
    {
        string[] opt = { Constants.TECHOPT_NONE };
        return opt;
    }

    public override void Use(int tpIndex, Legend owner, Legend target, string techOption)
    {
        if (tpIndex < techParts.Length)
        {
            if (techParts[tpIndex] is Strike)
            {
                Strike strike = techParts[tpIndex] as Strike;

                if (target.GetHealth().AtFullHealth())
                {
                    strike.SetDamageParameters(techDamageType, maxDamage);
                }
                else
                {
                    strike.SetDamageParameters(techDamageType, minDamage);
                }
            }
        }
        base.Use(tpIndex, owner, target, techOption);
    }

    public override void UseOnConfirm(int tpIndex, Legend owner, Legend target, string techOption)
    {
        //no need for any confirming with this technique
        Use(tpIndex, owner, target, techOption);
    }
}
