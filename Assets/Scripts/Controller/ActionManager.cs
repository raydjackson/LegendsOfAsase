using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using LegendsOfAsaseEnums;

public class ActionManager : MonoBehaviourPunCallbacks
{
    public static ActionManager instance { get; private set; }

    public List<IAction> switchStepActions = new List<IAction>();
    public List<IAction> atkTechStepActions = new List<IAction>();

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Creates an Attack, Switch, or Technique action and adds it to the list for the round, both parameters should be constants
    /// </summary>
    /// <param name="actionType">Should always be Attack, Switch, a specific Technique, or a Withdraw</param>
    /// <param name="actionOption">Element of an Attack/Tech, direction of a switch, or technique option</param>
    public void CreateAction(string actionType, string actionOption, string player)
    {
        switch (actionType)
        {
            case Constants.ATTACK:
                if (player == Constants.PLAYER_1 || player == Constants.PLAYER_2)
                {
                    AttackAction atkAction = new AttackAction(FieldManager.instance.LegendAt(player, FieldPosition.Active), ElementChart.instance.elementDatabase[actionOption]);
                    atkTechStepActions.Add(atkAction);
                    Debug.Log($"{player}'s active legend will {atkAction.actionType} with the {atkAction.attackElement.ElementName} element");
                    //atkAction.ExecuteFirst(FieldManager.instance.LegendAt(Constants.OppositePlayer(player), FieldPosition.Active));
                }
                break;
            case Constants.SWITCH:
                if (player == Constants.PLAYER_1 || player == Constants.PLAYER_2)
                {
                    SwitchAction switchAction = new SwitchAction(player, actionOption);
                    switchStepActions.Add(switchAction);
                    Debug.Log($"{player}'s active legend will {switchAction.actionType} to the {switchAction.switchDirection}");
                    switchAction.ExecuteSecond(null);
                }
                break;
            case Constants.TECHNIQUE:
                if (player == Constants.PLAYER_1 || player == Constants.PLAYER_2)
                {
                    TechniqueAction techniqueAction = new TechniqueAction(FieldManager.instance.LegendAt(player, FieldPosition.Active), actionOption);
                    atkTechStepActions.Add(techniqueAction);
                    Debug.Log($"{player}'s active legend will {techniqueAction.actionType} to the {techniqueAction.techniqueOption}");
                    //techniqueAction.ExecuteFirst(FieldManager.instance.LegendAt(Constants.OppositePlayer(player), FieldPosition.Active));
                    //techniqueAction.ExecuteSecond(FieldManager.instance.LegendAt(Constants.OppositePlayer(player), FieldPosition.Active));
                }
                break;
            default:
                break;
        }
        switchStepActions.Sort(CompareActionSpeed);
        atkTechStepActions.Sort(CompareActionSpeed);
    }

    private int CompareActionSpeed(IAction x, IAction y)
    {
        int retval = x.GetSpeed().CompareTo(y.GetSpeed());
        retval *= -1; //want to sort from highest speed to lowest speed
        return retval;
    }

    private void PrintList(ICollection collection)
    {
        foreach (var item in collection)
        {
            if (item is IAction)
            {
                IAction action = item as IAction;
                Debug.Log($"{action.GetActingLegendName()} will be {action.GetActionType()} at Speed {action.GetSpeed()}");
            }
        }
    }
}
