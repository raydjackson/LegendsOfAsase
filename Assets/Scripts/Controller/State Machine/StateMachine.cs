using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StateMachine : MonoBehaviour
{
    public TMP_Text stateIndicator;
    [SerializeField]
    protected State currentState;
    protected bool inTransition;
    public virtual State CurrentState
    {
        get { return currentState; }
        set { Transition(value); }
    }

    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
        {
            target = gameObject.AddComponent<T>();
        }
        return target;
    }

    public virtual void ChangeState<T>() where T : State
    {
        CurrentState = GetState<T>();
        if (stateIndicator == null)
        {
            stateIndicator = GameManager.instance.stateIndicator;
        }
        stateIndicator.text = CurrentState.ToString();
    }

    public virtual void ChangeState(State previoulsyVisitedState)
    {
        if (previoulsyVisitedState == null)
        {
            Debug.LogError("Can't change to a null state");
        }

        CurrentState = previoulsyVisitedState;
        if (stateIndicator == null)
        {
            stateIndicator = GameManager.instance.stateIndicator;
        }
        stateIndicator.text = CurrentState.ToString();
    }

    protected virtual void Transition(State value)
    {
        if (currentState == value || inTransition)
        {
            return;
        }

        inTransition = true;

        if (currentState != null)
        {
            currentState.Exit();
        }

        EventSystem.current.SetSelectedGameObject(null);
        currentState = value;

        if (currentState != null)
        {
            currentState.Enter();
        }

        inTransition = false;
    }
}
