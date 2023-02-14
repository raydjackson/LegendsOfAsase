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

    [Header("Player One Legends")]
    public Legend p1ActiveLegend;
    public Legend p1SupportLeftLegend;
    public Legend p1SupportRightLegend;
    public Legend p1WithdrawOneLegend;
    public Legend p1WithdrawTwoLegend;
    public Legend p1WithdrawThreeLegend;

    [Header("Player Two Legends")]
    public Legend p2ActiveLegend;
    public Legend p2SupportLeftLegend;
    public Legend p2SupportRightLegend;
    public Legend p2WithdrawOneLegend;
    public Legend p2WithdrawTwoLegend;
    public Legend p2WithdrawThreeLegend;
    #endregion

    private void Awake()
    {
        instance = this;
        BuildFieldDictionaries();
    }

    private void Start()
    {

    }

    public void CreateTestPlaycards()
    {
        Playcard pC1 = Instantiate(activePlaycard, activePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC2 = Instantiate(activePlaycard, activePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC3 = Instantiate(basicPlaycard, supportLeftPlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC4 = Instantiate(basicPlaycard, supportRightPlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC5 = Instantiate(basicPlaycard, withdrawOnePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC6 = Instantiate(basicPlaycard, withdrawTwoPlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC7 = Instantiate(basicPlaycard, withdrawThreePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC8 = Instantiate(basicPlaycard, supportLeftPlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC9 = Instantiate(basicPlaycard, supportRightPlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC10 = Instantiate(basicPlaycard, withdrawOnePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC11 = Instantiate(basicPlaycard, withdrawTwoPlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC12 = Instantiate(basicPlaycard, withdrawThreePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        pC1.legend = GameManager.instance.availableLegends[0];
        p1ActiveLegend = pC1.legend;
        pC2.legend = GameManager.instance.availableLegends[2];
        p2ActiveLegend = pC2.legend;
        //pC3.legend = GameManager.instance.example;
        //pC4.legend = GameManager.instance.example;
        //pC5.legend = GameManager.instance.example;
        //pC6.legend = GameManager.instance.example;
        //pC7.legend = GameManager.instance.example;
        //pC8.legend = GameManager.instance.example;
        //pC9.legend = GameManager.instance.example;
        //pC10.legend = GameManager.instance.example;
        //pC11.legend = GameManager.instance.example;
        //pC12.legend = GameManager.instance.example;
    }

    #region Dictionaries
    public Dictionary<FieldPosition, Transform> p1Transforms = new Dictionary<FieldPosition, Transform>();
    public Dictionary<FieldPosition, Transform> p2Transforms = new Dictionary<FieldPosition, Transform>();
    public Dictionary<FieldPosition, Legend> p1Legends = new Dictionary<FieldPosition, Legend>();
    public Dictionary<FieldPosition, Legend> p2Legends = new Dictionary<FieldPosition, Legend>();

    private void BuildFieldDictionaries()
    {
        BuildTransformDictionaries();
        BuildLegendDictionaries();
    }

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

    private void BuildLegendDictionaries()
    {
        //Player 1 Legends
        p1Legends.Add(FieldPosition.Active, p1ActiveLegend);
        p1Legends.Add(FieldPosition.SupportLeft, p1SupportLeftLegend);
        p1Legends.Add(FieldPosition.SupportRight, p1SupportRightLegend);
        p1Legends.Add(FieldPosition.WithdrawOne, p1WithdrawOneLegend);
        p1Legends.Add(FieldPosition.WithdrawTwo, p1WithdrawTwoLegend);
        p1Legends.Add(FieldPosition.WithdrawThree, p1WithdrawThreeLegend);

        //Player 2 Legends
        p2Legends.Add(FieldPosition.Active, p2ActiveLegend);
        p2Legends.Add(FieldPosition.SupportLeft, p2SupportLeftLegend);
        p2Legends.Add(FieldPosition.SupportRight, p2SupportRightLegend);
        p2Legends.Add(FieldPosition.WithdrawOne, p2WithdrawOneLegend);
        p2Legends.Add(FieldPosition.WithdrawTwo, p2WithdrawTwoLegend);
        p2Legends.Add(FieldPosition.WithdrawThree, p2WithdrawThreeLegend);
    }
    #endregion
}
