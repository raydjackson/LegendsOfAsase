using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public static PanelManager instance { get; private set; }

    #region Panel References
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
    #endregion

    private void Awake()
    {
        instance = this;
    }

    #region Action Panel Methods
    public void ShowActionPanels()
    {
        attackPanel.SetActive(true);
        switchPanel.SetActive(true);
        techniquePanel.SetActive(true);
    }

    public void HideActionPanels()
    {
        attackPanel.SetActive(false);
        switchPanel.SetActive(false);
        techniquePanel.SetActive(false);
    }
    #endregion

    #region Attack Option Methods
    public void ShowAttackOptionPanel()
    {
        attackOptionsPanel.SetActive(true);
        attackBackButton.gameObject.SetActive(true);
    }

    public void HideAttackOptionPanel()
    {
        attackOptionsPanel.SetActive(false);
        attackBackButton.gameObject.SetActive(false);
    }

    public void UpdateAttackPanel(Legend activeLegend)
    {
        Element[] actLegElements = activeLegend.GetElements();

        for (int i = 0; i < attackElements.Length; i++)
        {
            if (i == 1 && attackElements.Length > actLegElements.Length)
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
    #endregion

    #region Switch Option Methods
    public void ShowSwitchOptionPanel()
    {
        switchOptionsPanel.SetActive(true);
        switchBackButton.gameObject.SetActive(true);
    }

    public void HideSwitchOptionPanel()
    {
        switchOptionsPanel.SetActive(false);
        switchBackButton.gameObject.SetActive(false);
    }
    #endregion

    #region Technique Option Methods
    public void ShowTechniqueOptionPanel()
    {
        techniqueOptionsPanel.SetActive(true);
        techniqueBackButton.gameObject.SetActive(true);
    }

    public void HideTechniqueOptionPanel()
    {
        techniqueOptionsPanel.SetActive(false);
        techniqueBackButton.gameObject.SetActive(false);
    }
    #endregion
}
