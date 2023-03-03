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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
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

    public void AddHazardModP1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FieldManager.instance.AddFieldMod(Constants.PLAYER_1, ModType.Hazard, 1);
        }
    }

    public void AddHazardModP2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FieldManager.instance.AddFieldMod(Constants.PLAYER_2, ModType.Hazard, 1);
        }
    }

    public void UseHazardMods(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FieldManager.instance.UseFieldMod(Constants.PLAYER_1, ModType.Hazard, 1);
            FieldManager.instance.UseFieldMod(Constants.PLAYER_2, ModType.Hazard, 1);
        }
    }

    public void AddPowerModActive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.Active].legend.AddEquipMod<Power>(1);
        }
    }

    public void AddPowerModSupportLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //FieldManager.instance.AddFieldMod<Speed>(Constants.PLAYER_2, 1);
            FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.SupportLeft].legend.AddEquipMod<Power>(1);
        }
    }

    public void AddPowerModSupportRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.SupportRight].legend.AddEquipMod<Power>(1);
        }
    }

    public void UsePowerMods(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.Active].legend.UseEquipMod<Power>(1);
            FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.SupportLeft].legend.UseEquipMod<Power>(1);
            FieldManager.instance.playcards[Constants.PLAYER_1][FieldPosition.SupportRight].legend.UseEquipMod<Power>(1);
        }
    }
}
