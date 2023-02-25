using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LegendsOfAsaseEnums;

public class Playcard : MonoBehaviour
{
    public TMP_Text legendName;
    public TMP_Text health;
    public Image elementOne;
    public Image elementTwo;
    public Legend legend;
    public GameObject powerMod;
    public TMP_Text powerModText;
    public GameObject shieldMod;
    public TMP_Text shieldModText;

    private void Update()
    {
        SetFields();
    }

    protected virtual void SetFields()
    {
        if (legend != null)
        {
            SetName();
            SetHealth();
            SetElements();
            SetEquipMods();
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    protected virtual void SetName()
    {
        legendName.text = legend.GetShortName();
    }

    protected void SetHealth()
    {
        health.text = legend.GetHealth().currentHealth.ToString();
    }

    protected void SetElements()
    {
        Element[] ele = legend.GetElements();
        if (ele.Length == 1)
        {
            elementOne.sprite = ele[0].ElementIcon;
            elementOne.color = ele[0].ElementColor;
            elementTwo.gameObject.SetActive(false);
        }
        else
        {
            elementOne.sprite = ele[0].ElementIcon;
            elementOne.color = ele[0].ElementColor;
            elementTwo.sprite = ele[1].ElementIcon;
            elementTwo.color = ele[1].ElementColor;
            elementTwo.gameObject.SetActive(true);
        }
    }

    protected void SetEquipMods()
    {
        if (legend.equipMods.Count > 0)
        {
            foreach (EquipMod mod in legend.equipMods)
            {
                if (mod is Power)
                {
                    if (mod.GetCountOfMod() > 0)
                    {
                        powerModText.text = mod.GetCountOfMod().ToString();
                        powerMod.SetActive(true);
                    }
                    else
                    {
                        powerMod.SetActive(false);
                    }
                }
                else if (mod is Shield)
                {
                    if (mod.GetCountOfMod() > 0)
                    {
                        shieldModText.text = mod.GetCountOfMod().ToString();
                        shieldMod.SetActive(true);
                    }
                    else
                    {
                        shieldMod.SetActive(false);
                    }
                }
            }
        }
        else
        {
            powerMod.SetActive(false);
            shieldMod.SetActive(false);
        }
    }

    public void SetLegend(Legend legend)
    {
        this.legend = legend;
    }
}
