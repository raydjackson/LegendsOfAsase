using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TechPart : MonoBehaviour
{
    public string partName;
    public bool requiresConfirmChoice;

    protected virtual void Start()
    {

    }

    public virtual void ActivatePart(Legend owner, Legend target, string techOption)
    {

    }

    public virtual void ActivatePartAfterConfirm(Legend owner, Legend target, string techOption)
    {

    }
}
