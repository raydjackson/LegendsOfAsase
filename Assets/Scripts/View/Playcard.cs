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

    private void Update()
    {
        SetFields();
    }

    protected virtual void SetFields()
    {
        SetName();
        SetHealth();
        SetElements();
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
}
