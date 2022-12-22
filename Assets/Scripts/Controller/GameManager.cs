using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Playcard selectedPlaycard = null;
    public LayerMask fieldLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(InputAction.CallbackContext context)
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
