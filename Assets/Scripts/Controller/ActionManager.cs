using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using LegendsOfAsaseEnums;

public class ActionManager : MonoBehaviourPunCallbacks
{
    public static ActionManager instance { get; private set; }

    List<IAction> actions = new List<IAction>();

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
                    actions.Add(atkAction);
                    Debug.Log($"{player}'s active legend will {atkAction.actionType} with the {atkAction.attackElement.ElementName} element");
                    atkAction.ExecuteFirst(FieldManager.instance.LegendAt(Constants.OppositePlayer(player), FieldPosition.Active));
                }
                break;
            case Constants.SWITCH:
                if (player == Constants.PLAYER_1 || player == Constants.PLAYER_2)
                {
                    SwitchAction switchAction = new SwitchAction(player, actionOption);
                    actions.Add(switchAction);
                    Debug.Log($"{player}'s active legend will {switchAction.actionType} to the {switchAction.switchDirection}");
                    switchAction.ExecuteSecond(null);
                }
                break;
            default:
                break;
        }
    }
}
