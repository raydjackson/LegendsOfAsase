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
    private Sprite defTechIcon;
    private Color defTechColor;

    [Header("Withdraw Panel")]
    public GameObject withdrawPanel;
    public Button[] withdrawOutOptions;
    public TMP_Text[] withdrawOutOptionTexts;
    public Button[] withdrawInOptions;
    public TMP_Text[] withdrawInOptionTexts;
    public Button noWithdrawButton;
    public Button withdrawBackButton;
    #endregion

    private void Awake()
    {
        instance = this;
        DefaultTechniqueIcon(techniqueOptionIcons[0]);
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

    private void DefaultTechniqueIcon(Image icon)
    {
        defTechIcon = icon.sprite;
        defTechColor = icon.color;
    }

    public void UpdateTechniquePanel(Legend activeLegend)
    {
        string[] techOptions = activeLegend.legendTech.GetTechOptions();

        for (int i = 0; i < techniqueOptions.Length; i++)
        {
            if (i == 1 && techniqueOptions.Length > techOptions.Length)
            {
                techniqueOptions[i].gameObject.SetActive(false);
                continue;
            }
            else
            {
                techniqueOptions[i].gameObject.SetActive(true);
                if (ElementChart.instance.elementDatabase.ContainsKey(techOptions[i]))
                {
                    Element ele = ElementChart.instance.elementDatabase[techOptions[i]];
                    techniqueOptionIcons[i].sprite = ele.ElementIcon;
                    techniqueOptionIcons[i].color = ele.ElementColor;
                    techniqueOptionTexts[i].text = techOptions[i];
                }
                else
                {
                    techniqueOptionIcons[i].sprite = defTechIcon;
                    techniqueOptionIcons[i].color = defTechColor;
                    if (techOptions[i] == Constants.TECHOPT_NONE)
                    {
                        techniqueOptionTexts[i].text = activeLegend.legendTech.techniqueName;
                    }
                    else
                    {
                        techniqueOptionTexts[i].text = techOptions[i];
                    }
                }
            }
        }
    }
    #endregion

    #region Withdraw Methods

    public void ShowWithdrawPanel()
    {
        withdrawPanel.SetActive(true);
        withdrawBackButton.gameObject.SetActive(true);
        noWithdrawButton.gameObject.SetActive(true);
    }

    public void HideWithdrawPanel()
    {
        withdrawPanel.SetActive(false);
        withdrawBackButton.gameObject.SetActive(false);
        noWithdrawButton.gameObject.SetActive(false);
    }

    public void UpdateWithdrawPanel(string player, string withdrawType)
    {
        Legend[] comingInLegends = FieldManager.instance.GetWithdrawLegends(player);
        Legend[] goingOutLegends = { null };
        if (withdrawType == Constants.WITHDRAW_SPT)
        {
            goingOutLegends = FieldManager.instance.GetSupportLegends(player);
        }
        else if (withdrawType == Constants.WITHDRAW_ACT)
        {
            goingOutLegends[0] = FieldManager.instance.LegendAt(player, LegendsOfAsaseEnums.FieldPosition.Active);
        }

        for (int i = 0; i < withdrawOutOptions.Length; i++)
        {
            if (i + 1 > goingOutLegends.Length)
            {
                withdrawOutOptions[i].gameObject.SetActive(false);
            }
            else
            {
                withdrawOutOptionTexts[i].text = goingOutLegends[i].GetShortName();
                withdrawOutOptions[i].gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < withdrawInOptions.Length; i++)
        {
            if (i + 1 > comingInLegends.Length)
            {
                withdrawInOptions[i].gameObject.SetActive(false);
            }
            else
            {
                withdrawInOptionTexts[i].text = comingInLegends[i].GetShortName();
                withdrawInOptions[i].gameObject.SetActive(true);
            }
        }

    }

    #endregion
}
