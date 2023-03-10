using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Technique : MonoBehaviourPunCallbacks
{
    public Legend owner;
    public string techniqueName;
    [TextArea]
    public string description;
    public TechPart[] techParts;
    
    public virtual void Use(int tpIndex, Legend owner, Legend target, string techOption)
    {
        if (tpIndex < techParts.Length)
        {
            techParts[tpIndex].ActivatePart(owner, target, techOption);
        }
        else
        {
            Debug.Log($"Only {techParts.Length} TechParts found.");
        }
    }

    public virtual void UseOnConfirm(int tpIndex, Legend owner, Legend target, string techOption)
    {
        if (tpIndex < techParts.Length)
        {
            techParts[tpIndex].ActivatePartAfterConfirm(owner, target, techOption);
        }
    }

    public virtual string[] GetTechOptions()
    {
        string[] def = { "Default Message: Make Sure Tech Options Are Defined" };
        return def;
    }
}
