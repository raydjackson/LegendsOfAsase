using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject attackerPrefab;
    [SerializeField]
    public GameObject defenderPrefab;

    public Legend attacker;
    public Legend defender;

    // Start is called before the first frame update
    void Start()
    {
        attacker = attackerPrefab.GetComponent<Legend>();
        defender = defenderPrefab.GetComponent<Legend>();
        DamageType dT = ElementChart.instance.DetermineWeaknessAndResistance(attacker.GetElement2(), defender);
        Debug.Log(dT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
