using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public const string PLAYER_1 = "Player1";
    public const string PLAYER_2 = "Player2";
    public const string ATTACK = "Attack";
    public const string SWITCH = "Switch";
    public const string TECHNIQUE = "Technique";
    public const string WITHDRAW_ACT = "WithdrawActive";
    public const string WITHDRAW_SPT = "WithdrawSupport";
    public const string SWITCH_LEFT = "SwitchLeft";
    public const string SWITCH_RIGHT = "SwitchRight";

    public const string FIELD_ACTIVE = "FieldPositionActive";
    public const string FIELD_SPTLFT = "FieldPositionSupportLeft";
    public const string FIELD_SPTRGT = "FieldPositionSupportRight";
    public const string FIELD_WDONE = "FieldPositionWithdrawOne";
    public const string FIELD_WDTWO = "FieldPositionWithdrawTwo";
    public const string FIELD_WDTHREE = "FieldPositionWithdrawThree";

    public const string TECHOPT_NONE = "No Tech Options";

    public static string OppositePlayer(string player)
    {
        if (player == PLAYER_1)
        {
            return PLAYER_2;
        }
        else if (player == PLAYER_2)
        {
            return PLAYER_1;
        }

        return null;
    }
}
