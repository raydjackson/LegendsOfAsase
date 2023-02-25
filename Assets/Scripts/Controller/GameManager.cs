using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Legend example;
    public GameObject[] availableLegends;
    public Playcard selectedPlaycard = null;
    public LayerMask fieldLayer;
    public TMPro.TMP_Text stateIndicator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameObject.AddComponent<GameStateMachine>();
    }

    public void Select(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.TryGetComponent(out selectedPlaycard))
            {
                Debug.Log(selectedPlaycard.legend.GetShortName());
            }
            else
            {
                Debug.Log("No Playcard Detected");
            }
        }
    }

    public void AddPowerMod(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Legend actLegend = FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.Active].legend;
            actLegend.AddEquipMod<Power>(1);
        }
    }

    public void RemovePowerMod(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Legend actLegend = FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.Active].legend;
            actLegend.UseEquipMod<Power>(1);
        }
    }
}
