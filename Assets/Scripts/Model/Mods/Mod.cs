using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfAsaseEnums;

public class Mod : MonoBehaviour
{
    public int count = 0;
    public ModType modtype;

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
