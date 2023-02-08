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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Playcard pC = Instantiate(basicPlaycard, activePlayerOne.position, Quaternion.identity).GetComponent<Playcard>();
        Playcard pC2 = Instantiate(basicPlaycard, activePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        //Playcard pC3 = Instantiate(basicPlaycard, withdrawThreePlayerTwo.position, Quaternion.identity).GetComponent<Playcard>();
        pC.legend = GameManager.instance.availableLegends[0];
        pC2.legend = GameManager.instance.availableLegends[1];
        //pC3.legend = GameManager.instance.example;
    }
}
