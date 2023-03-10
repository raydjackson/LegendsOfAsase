using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;
using Photon.Pun;

public class Mod : MonoBehaviourPunCallbacks
{
    public int count = 0;
    public ModType modType;

    public int GetCountOfMod()
    {
        return count;
    }

    public void AddCount(int amount)
    {
        count += amount;
    }

    public void RemoveCount(int amount)
    {
        count -= amount;
    }
}
