using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legend : MonoBehaviour
{
    [SerializeField]
    private string fullName = null;
    [SerializeField]
    private Element[] elements;
    [SerializeField]
    private int speed = 0;
    //Health
    //Personnel
    //Effect/Ability

    private void Start()
    {

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
        return elements[1];
    }

    public int GetSpeed()
    {
        return speed;
    }

    //public Health GetHealth()
    //{
    //    if (legendHealth == null)
    //    {
    //        legendHealth = this.gameObject.AddComponent<Health>() as Health;
    //    }

    //    return legendHealth;
    //}
}
