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

    public virtual void Activate(Legend owner, Legend target, string techOption)
    {

    }

    public virtual void ActivateOnConfirm(Legend owner, Legend target, string techOption)
    {

    }
}
