using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;
using TMPro;

public class FieldManager : MonoBehaviour
{
    public static FieldManager instance { get; private set; }

    #region Serialized Fields
    [SerializeField]
    public GameObject basicPlaycard;
    [SerializeField]
    public GameObject activePlaycard;

    [Header("Player One Field Transforms")]
    public Transform activePlayerOne;
    public Transform supportLeftPlayerOne;
    public Transform supportRightPlayerOne;
    public Transform withdrawOnePlayerOne;
    public Transform withdrawTwoPlayerOne;
    public Transform withdrawThreePlayerOne;

    [Header("Player One Field Mods")]
    public GameObject p1FieldMods;
    public GameObject p1Hazard;
    public TMP_Text p1HazardText;
    public GameObject p1Speed;
    public TMP_Text p1SpeedText;

    [Header("Player Two Field Transforms")]
    public Transform activePlayerTwo;
    public Transform supportLeftPlayerTwo;
    public Transform supportRightPlayerTwo;
    public Transform withdrawOnePlayerTwo;
    public Transform withdrawTwoPlayerTwo;
    public Transform withdrawThreePlayerTwo;

    [Header("Player Two Field Mods")]
    public GameObject p2FieldMods;
    public GameObject p2Hazard;
    public TMP_Text p2HazardText;
    public GameObject p2Speed;
    public TMP_Text p2SpeedText;
    #endregion

    #region Mod References
    [Header("Mod References")]
    public GameObject powerMod;
    public GameObject shieldMod;
    public GameObject hazardMod;
    public GameObject speedMod;
    #endregion

    #region Dictionaries
    public Dictionary<string, Dictionary<FieldPosition, Playcard>> playcards = new Dictionary<string, Dictionary<FieldPosition, Playcard>>();
    public Dictionary<string, Dictionary<FieldPosition, Transform>> transforms = new Dictionary<string, Dictionary<FieldPosition, Transform>>();
    public Dictionary<string, Dictionary<ModType, GameObject>> fieldMods = new Dictionary<string, Dictionary<ModType, GameObject>>();

    private void BuildTransformDictionaries()
    {
        Dictionary<FieldPosition, Transform> p1Transforms = new Dictionary<FieldPosition, Transform>();
        Dictionary<FieldPosition, Transform> p2Transforms = new Dictionary<FieldPosition, Transform>();

        //Player 1 Transforms
        p1Transforms.Add(FieldPosition.Active, activePlayerOne);
        p1Transforms.Add(FieldPosition.SupportLeft, supportLeftPlayerOne);
        p1Transforms.Add(FieldPosition.SupportRight, supportRightPlayerOne);
        p1Transforms.Add(FieldPosition.WithdrawOne, withdrawOnePlayerOne);
        p1Transforms.Add(FieldPosition.WithdrawTwo, withdrawTwoPlayerOne);
        p1Transforms.Add(FieldPosition.WithdrawThree, withdrawThreePlayerOne);

        //Player 2 Transforms
        p2Transforms.Add(FieldPosition.Active, activePlayerTwo);
        p2Transforms.Add(FieldPosition.SupportLeft, supportLeftPlayerTwo);
        p2Transforms.Add(FieldPosition.SupportRight, supportRightPlayerTwo);
        p2Transforms.Add(FieldPosition.WithdrawOne, withdrawOnePlayerTwo);
        p2Transforms.Add(FieldPosition.WithdrawTwo, withdrawTwoPlayerTwo);
        p2Transforms.Add(FieldPosition.WithdrawThree, withdrawThreePlayerTwo);

        transforms.Add(Constants.PLAYER_1, p1Transforms);
        transforms.Add(Constants.PLAYER_2, p2Transforms);
    }
    #endregion

    private void Awake()
    {
        instance = this;
        BuildTransformDictionaries();
        BuildFieldModDictionaries();
    }

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void CreateTestPlaycards()
    {
        Dictionary<FieldPosition, Playcard> p1Playcards = new Dictionary<FieldPosition, Playcard>();
        Dictionary<FieldPosition, Playcard> p2Playcards = new Dictionary<FieldPosition, Playcard>();

        Playcard pC1 = Instantiate(activePlaycard, activePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC2 = Instantiate(activePlaycard, activePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC3 = Instantiate(basicPlaycard, supportLeftPlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC4 = Instantiate(basicPlaycard, supportRightPlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC5 = Instantiate(basicPlaycard, withdrawOnePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC6 = Instantiate(basicPlaycard, withdrawTwoPlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC7 = Instantiate(basicPlaycard, withdrawThreePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC8 = Instantiate(basicPlaycard, supportLeftPlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC9 = Instantiate(basicPlaycard, supportRightPlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC10 = Instantiate(basicPlaycard, withdrawOnePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC11 = Instantiate(basicPlaycard, withdrawTwoPlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC12 = Instantiate(basicPlaycard, withdrawThreePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        
        pC1.SetLegend(Instantiate(GameManager.instance.availableLegends[0]).GetComponent<Legend>());
        pC2.SetLegend(Instantiate(GameManager.instance.availableLegends[2]).GetComponent<Legend>());
        pC3.SetLegend(Instantiate(GameManager.instance.availableLegends[1]).GetComponent<Legend>());
        pC4.SetLegend(Instantiate(GameManager.instance.availableLegends[2]).GetComponent<Legend>());
        //pC5.legend = GameManager.instance.example;
        //pC6.legend = GameManager.instance.example;
        //pC7.legend = GameManager.instance.example;
        pC8.SetLegend(Instantiate(GameManager.instance.availableLegends[0]).GetComponent<Legend>());
        pC9.SetLegend(Instantiate(GameManager.instance.availableLegends[1]).GetComponent<Legend>());
        //pC10.legend = GameManager.instance.example;
        //pC11.legend = GameManager.instance.example;
        //pC12.legend = GameManager.instance.example;

        //Player 1 Playcards
        p1Playcards.Add(FieldPosition.Active, pC1);
        p1Playcards.Add(FieldPosition.SupportLeft, pC3);
        p1Playcards.Add(FieldPosition.SupportRight, pC4);
        //p1Playcards.Add(FieldPosition.WithdrawOne, pC5);
        //p1Playcards.Add(FieldPosition.WithdrawTwo, pC6);
        //p1Playcards.Add(FieldPosition.WithdrawThree, pC7);

        //Player 2 Playcards
        p2Playcards.Add(FieldPosition.Active, pC2);
        p2Playcards.Add(FieldPosition.SupportLeft, pC8);
        p2Playcards.Add(FieldPosition.SupportRight, pC9);
        //p2Playcards.Add(FieldPosition.WithdrawOne, pC10);
        //p2Playcards.Add(FieldPosition.WithdrawTwo, pC11);
        //p2Playcards.Add(FieldPosition.WithdrawThree, pC12);

        playcards.Add(Constants.PLAYER_1, p1Playcards);
        playcards.Add(Constants.PLAYER_2, p2Playcards);
    }

    #region Switching
    public void SwitchLegends(string player, string switchDirection)
    {
        Legend tempLeg = playcards[player][FieldPosition.Active].legend;
        if (switchDirection == Constants.SWITCH_LEFT)
        {
            playcards[player][FieldPosition.Active].SetLegend(playcards[player][FieldPosition.SupportLeft].legend);
            playcards[player][FieldPosition.SupportLeft].SetLegend(tempLeg);
        }
        else if (switchDirection == Constants.SWITCH_RIGHT)
        {
            playcards[player][FieldPosition.Active].SetLegend(playcards[player][FieldPosition.SupportRight].legend);
            playcards[player][FieldPosition.SupportRight].SetLegend(tempLeg);
        }
    }
    #endregion

    #region Field Mods
    private void BuildFieldModDictionaries()
    {
        fieldMods.Add(Constants.PLAYER_1, new Dictionary<ModType, GameObject>());
        fieldMods.Add(Constants.PLAYER_2, new Dictionary<ModType, GameObject>());
    }

    private void UpdateFieldModUI()
    {
        //Player 1 Mods
        if (fieldMods[Constants.PLAYER_1].Count > 0)
        {
            foreach (KeyValuePair<ModType,GameObject> modTypeDict in fieldMods[Constants.PLAYER_1])
            {
                FieldMod fieldMod = modTypeDict.Value.GetComponent<FieldMod>();
                if (modTypeDict.Key == ModType.Hazard)
                {
                    if (fieldMod.GetCountOfMod() > 0)
                    {
                        p1HazardText.text = fieldMod.GetCountOfMod().ToString();
                        p1Hazard.SetActive(true);
                    }
                    else
                    {
                        p1Hazard.SetActive(false);
                    }
                }
                else if (modTypeDict.Key == ModType.Speed)
                {
                    if (fieldMod.GetCountOfMod() > 0)
                    {
                        p1SpeedText.text = fieldMod.GetCountOfMod().ToString();
                        p1Speed.SetActive(true);
                    }
                    else
                    {
                        p1Speed.SetActive(false);
                    }
                }
            }
        }
        else
        {
            p1Hazard.SetActive(false);
            p1Speed.SetActive(false);
        }

        //Player 2 Mods
        if (fieldMods[Constants.PLAYER_2].Count > 0)
        {
            foreach (KeyValuePair<ModType, GameObject> modTypeDict in fieldMods[Constants.PLAYER_2])
            {
                FieldMod fieldMod = modTypeDict.Value.GetComponent<FieldMod>();
                if (modTypeDict.Key == ModType.Hazard)
                {
                    if (fieldMod.GetCountOfMod() > 0)
                    {
                        p2HazardText.text = fieldMod.GetCountOfMod().ToString();
                        p2Hazard.SetActive(true);
                    }
                    else
                    {
                        p2Hazard.SetActive(false);
                    }
                }
                else if (modTypeDict.Key == ModType.Speed)
                {
                    if (fieldMod.GetCountOfMod() > 0)
                    {
                        p2SpeedText.text = fieldMod.GetCountOfMod().ToString();
                        p2Speed.SetActive(true);
                    }
                    else
                    {
                        p2Speed.SetActive(false);
                    }
                }
            }
        }
        else
        {
            p2Hazard.SetActive(false);
            p2Speed.SetActive(false);
        }
    }

    public void AddFieldMod(string player, ModType modType, int amount)
    {
        GameObject modToMake;
        if (modType == ModType.Hazard)
        {
            modToMake = hazardMod;
        }
        else if (modType == ModType.Speed)
        {
            modToMake = speedMod;
        }
        else
        {
            return;
        }


        if (!fieldMods[player].ContainsKey(modType))
        {
            FieldMod fieldMod = null;

            if (player == Constants.PLAYER_1)
            {
                fieldMod = Instantiate(modToMake, p1FieldMods.transform).GetComponent<FieldMod>();
            }
            else if (player == Constants.PLAYER_2)
            {
                fieldMod = Instantiate(modToMake, p2FieldMods.transform).GetComponent<FieldMod>();
            }

            if (fieldMod != null)
            {
                fieldMod.AddCount(amount);
                fieldMods[player].Add(modType, fieldMod.gameObject);
            }
        }
        else
        {
            FieldMod fieldMod = fieldMods[player][modType].GetComponent<FieldMod>();
            fieldMod.AddCount(amount);
        }

        UpdateFieldModUI();
    }

    public void UseFieldMod(string player, ModType modType, int amount)
    {
        if (fieldMods[player].ContainsKey(modType))
        {
            FieldMod fieldMod = fieldMods[player][modType].GetComponent<FieldMod>();

            if (fieldMod.GetCountOfMod() > 0)
            {
                fieldMod.RemoveCount(amount);
                UpdateFieldModUI();
            }
        }
    }
    #endregion
}
