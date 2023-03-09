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
    public Technique legendTech;
    public List<EquipMod> equipMods = new List<EquipMod>();
    [SerializeField]
    protected GameObject technique;

    private void Start()
    {
        if (legendHealth != null)
        {
            legendHealth.InitializeHealth(this);
        }

        if (legendTech == null)
        {
            legendTech = Instantiate(technique, gameObject.transform).GetComponent<Technique>();
            legendTech.owner = this;
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
            if (!gameObject.TryGetComponent(out legendHealth))
            {
                legendHealth = gameObject.AddComponent<Health>();
            }
            legendHealth.InitializeHealth(this);
        }

        if (legendHealth.owner == null)
        {
            legendHealth.SetOwner(this);
        }

        return legendHealth;
    }

    public bool IsAlive()
    {
        return legendHealth.currentHealth > 0;
    }

    public T AddEquipMod<T>(int amount) where T : EquipMod
    {
        T equipMod;

        if (!TryGetComponent(out equipMod))
        {
            equipMod = gameObject.AddComponent<T>();
        }

        equipMod.AddCount(amount);

        if (!equipMods.Contains(equipMod))
        {
            equipMods.Add(equipMod);
        }

        return equipMod;
    }

    public void UseEquipMod<T>(int amount) where T : EquipMod
    {
        if (TryGetComponent(out T equipMod))
        {
            equipMod.RemoveCount(amount);
            if (equipMod.GetCountOfMod() <= 0)
            {
                RemoveEquipMod<T>();
            }
        }
    }

    public void RemoveEquipMod<T>() where T : EquipMod
    {
        if (TryGetComponent(out T equipMod))
        {
            equipMods.Remove(equipMod);
            Destroy(equipMod);
        }
    }
}
