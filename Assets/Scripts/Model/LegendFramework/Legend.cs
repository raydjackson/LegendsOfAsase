using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legend : MonoBehaviour
{
    [SerializeField]
    protected string fullName = null;
    [SerializeField]
    protected Element[] elements;
    [SerializeField]
    protected int speed = 0;
    protected Health legendHealth;
    //Personnel
    //Effect/Ability

    private void Start()
    {
        if (legendHealth != null)
        {
            legendHealth.InitializeHealth(this);
        }
    }

    public string GetFullName()
    {
        return fullName;
    }

    public string GetShortName()
    {
        return fullName.Split(',')[0];
    }

    public Element[] GetElements()
    {
        return elements;
    }

    public Element GetElement1()
    {
        return elements[0];
    }

    public Element GetElement2()
    {
        if (elements.Length == 1)
        {
            //For single element legends
            return elements[0];
        }

        return elements[1];
    }

    public int GetSpeed()
    {
        return speed;
    }

    public Health GetHealth()
    {
        if (legendHealth == null)
        {
            if (!gameObject.TryGetComponent<Health>(out legendHealth))
            {
                legendHealth = gameObject.AddComponent<Health>() as Health;
            }
            legendHealth.InitializeHealth(this);
        }

        if (legendHealth.owner == null)
        {
            legendHealth.SetOwner(this);
        }

        return legendHealth;
    }
}
