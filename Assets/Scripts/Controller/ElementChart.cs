using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class ElementChart : MonoBehaviour
{
    [SerializeField]
    private Element[] elementPrefabs = new Element[8];

    public static ElementChart instance { get; private set; }
    public Dictionary<string, Element> elementDatabase = new Dictionary<string, Element>();

    private void Awake()
    {
        instance = this;
        PopulateElementDatabase();
    }

    private void PopulateElementDatabase()
    {
        foreach (Element e in elementPrefabs)
        {
            elementDatabase.Add(e.ElementName, e);
        }
    }

    public DamageType DetermineWeaknessAndResistance(Element attackingElement, Legend defendingLegend)
    {
        DamageType[] damageTypes = CheckWeakAndResist(attackingElement, defendingLegend);

        if (damageTypes.Length == 1)
        {
            if (damageTypes[0] != DamageType.None)
            {
                return damageTypes[0];
            }
        }
        else if (damageTypes.Length == 2)
        {
            if (damageTypes[0] == DamageType.Weakness)
            {
                if (damageTypes[1] == DamageType.Weakness || damageTypes[1] == DamageType.Standard)
                {
                    return DamageType.Weakness;
                }
                else if (damageTypes[1] == DamageType.Resistance)
                {
                    return DamageType.Standard;
                }
            }
            else if (damageTypes[0] == DamageType.Resistance)
            {
                if (damageTypes[1] == DamageType.Resistance || damageTypes[1] == DamageType.Standard)
                {
                    return DamageType.Resistance;
                }
                else if (damageTypes[1] == DamageType.Weakness)
                {
                    return DamageType.Standard;
                }
            }
            else if (damageTypes[0] == DamageType.Standard)
            {
                if (damageTypes[1] != DamageType.None)
                {
                    return damageTypes[1];
                }
            }
        }

        return DamageType.None;
    }

    public DamageType DetermineOnlyWeakness(Element attackingElement, Legend defendingLegend)
    {
        DamageType damageType = DetermineWeaknessAndResistance(attackingElement, defendingLegend);

        if (damageType == DamageType.Resistance)
        {
            return DamageType.Standard;
        }

        return damageType;
    }

    public DamageType DetermineOnlyResistance(Element attackingElement, Legend defendingLegend)
    {
        DamageType damageType = DetermineWeaknessAndResistance(attackingElement, defendingLegend);

        if (damageType == DamageType.Weakness)
        {
            return DamageType.Standard;
        }

        return damageType;
    }

    private DamageType[] CheckWeakAndResist(Element attackingElement, Legend defendingLegend)
    {
        Element[] defendingElements = defendingLegend.GetElements();
        DamageType[] damageTypes = new DamageType[defendingElements.Length];

        for (int i = 0; i < defendingElements.Length; i++)
        {
            if (defendingElements[i].IsWeakness(attackingElement))
            {
                damageTypes[i] = DamageType.Weakness;
            }
            else if (defendingElements[i].IsResistance(attackingElement))
            {
                damageTypes[i] = DamageType.Resistance;
            }
            else
            {
                damageTypes[i] = DamageType.Standard;
            }
        }

        return damageTypes;
    }
}
