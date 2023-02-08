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
    public Legend[] availableLegends;
    public Playcard selectedPlaycard = null;
    public LayerMask fieldLayer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Select();
        }
    }

    public void Select()
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
