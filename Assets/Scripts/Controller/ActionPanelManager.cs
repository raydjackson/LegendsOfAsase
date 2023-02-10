using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionPanelManager : MonoBehaviour
{
    public static ActionPanelManager instance { get; private set; }

    public GameObject instructionPanel;
    public TMP_Text instructionsText;

    [Header("Attack Panel")]
    public GameObject attackPanel;
    public Button attackButton;
    public GameObject attackOptionsPanel;
    public Button[] attackElements;
    public Image[] attackElementIcons;
    public TMP_Text[] attackElementTexts;
    public Button attackBackButton;

    [Header("Switch Panel")]
    public GameObject switchPanel;
    public Button switchButton;
    public GameObject switchOptionsPanel;
    public Button switchLeftButton;
    public Button switchRightButton;
    public Button switchBackButton;

    [Header("Technique Panel")]
    public GameObject techniquePanel;
    public Button techniqueButton;
    public GameObject techniqueOptionsPanel;
    public Button[] techniqueOptions;
    public Image[] techniqueOptionIcons;
    public TMP_Text[] techniqueOptionTexts;
    public Button techniqueBackButton;

    [Header("Withdraw Panel")]
    public GameObject withdrawPanel;
    //buttons for withdraw options
    public Button withdrawBackButton;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowActionPanels()
    {
        attackPanel.SetActive(true);
        switchPanel.SetActive(true);
        techniquePanel.SetActive(true);
        UpdateAttackPanel(FieldManager.instance.p1ActiveLegend);
        //UpdateTechniquePanel
    }

    public void UpdateAttackPanel(Legend activeLegend)
    {
        Element[] actLegElements = activeLegend.GetElements();

        for (int i = 0; i < attackElements.Length; i++)
        {
            if (i==1 && attackElements.Length > actLegElements.Length)
            {
                attackElements[i].gameObject.SetActive(false);
                continue;
            }
            else
            {
                attackElements[i].gameObject.SetActive(true);
                attackElementIcons[i].sprite = actLegElements[i].ElementIcon;
                attackElementIcons[i].color = actLegElements[i].ElementColor;
                attackElementTexts[i].text = actLegElements[i].ElementName;
            }
        }
    }

    public void AddAttackButtonListeners()
    {
        attackElements[0].onClick.AddListener(delegate { AttackWith(attackElementTexts[0].text); });
        if (attackElements[1].isActiveAndEnabled)
        {
            attackElements[1].onClick.AddListener(delegate { AttackWith(attackElementTexts[1].text); });
        }
    }

    public void RemoveAttackButtonListeners()
    {
        attackElements[0].onClick.RemoveAllListeners();
        attackElements[1].onClick.RemoveAllListeners();
    }

    public void AttackWith(string elementName)
    {
        Debug.Log("Attacking with " + elementName);
    }
}
