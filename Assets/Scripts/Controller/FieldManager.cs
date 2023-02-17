using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

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

    [Header("Player Two Field Transforms")]
    public Transform activePlayerTwo;
    public Transform supportLeftPlayerTwo;
    public Transform supportRightPlayerTwo;
    public Transform withdrawOnePlayerTwo;
    public Transform withdrawTwoPlayerTwo;
    public Transform withdrawThreePlayerTwo;
    #endregion

    #region Dictionaries
    public Dictionary<FieldPosition, Playcard> p1Playcards = new Dictionary<FieldPosition, Playcard>();
    public Dictionary<FieldPosition, Playcard> p2Playcards = new Dictionary<FieldPosition, Playcard>();
    public Dictionary<FieldPosition, Transform> p1Transforms = new Dictionary<FieldPosition, Transform>();
    public Dictionary<FieldPosition, Transform> p2Transforms = new Dictionary<FieldPosition, Transform>();

    private void BuildTransformDictionaries()
    {
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
    }
    #endregion

    private void Awake()
    {
        instance = this;
        BuildTransformDictionaries();
    }

    private void Start()
    {

    }

    public void CreateTestPlaycards()
    {
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
    }

    #region Switching
    public void SwitchLegends(string player, string switchDirection)
    {
        Legend tempLeg;
        if (player == Constants.PLAYER_1)
        {
            tempLeg = p1Playcards[FieldPosition.Active].legend;
            if (switchDirection == Constants.SWITCH_LEFT)
            {
                p1Playcards[FieldPosition.Active].SetLegend(p1Playcards[FieldPosition.SupportLeft].legend);
                p1Playcards[FieldPosition.SupportLeft].SetLegend(tempLeg);
            }
            else
            {
                p1Playcards[FieldPosition.Active].SetLegend(p1Playcards[FieldPosition.SupportRight].legend);
                p1Playcards[FieldPosition.SupportRight].SetLegend(tempLeg);
            }
        }
        else
        {
            tempLeg = p2Playcards[FieldPosition.Active].legend;
            if (switchDirection == Constants.SWITCH_LEFT)
            {
                p2Playcards[FieldPosition.Active].SetLegend(p2Playcards[FieldPosition.SupportLeft].legend);
                p2Playcards[FieldPosition.SupportLeft].SetLegend(tempLeg);
            }
            else
            {
                p2Playcards[FieldPosition.Active].SetLegend(p2Playcards[FieldPosition.SupportRight].legend);
                p2Playcards[FieldPosition.SupportRight].SetLegend(tempLeg);
            }
        }
    }
    #endregion
}
