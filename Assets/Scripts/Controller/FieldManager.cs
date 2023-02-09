using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class FieldManager : MonoBehaviour
{
    public static FieldManager instance { get; private set; }

    [SerializeField]
    public GameObject basicPlaycard;
    [SerializeField]
    public GameObject activePlaycard;

    [Header("Player One Zone Positions")]
    public Transform activePlayerOne;
    public Transform supportLeftPlayerOne;
    public Transform supportRightPlayerOne;
    public Transform withdrawOnePlayerOne;
    public Transform withdrawTwoPlayerOne;
    public Transform withdrawThreePlayerOne;

    [Header("Player Two Zone Positions")]
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

    [Header("Player One Legends")]
    public Legend p2ActiveLegend;
    public Legend p2SupportLeftLegend;
    public Legend p2SupportRightLegend;
    public Legend p2WithdrawOneLegend;
    public Legend p2WithdrawTwoLegend;
    public Legend p2WithdrawThreeLegend;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
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
        pC2.legend = GameManager.instance.availableLegends[1];
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
}
