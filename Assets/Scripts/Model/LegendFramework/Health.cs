using UnityEngine;
using LegendsOfAsaseEnums;

public class Health : MonoBehaviour
{
    public int currentHealth = 5;
    public int maximumHealth = 5;

    public void InitializeHealth()
    {
        maximumHealth = 5;
        currentHealth = maximumHealth;
    }

    public bool AtFullHealth()
    {
        if (currentHealth == maximumHealth)
        {
            return true;
        }

        return false;
    }

    public void PrepareDamage(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Standard:
                DealDamage(2);
                break;
            case DamageType.Weakness:
                DealDamage(4);
                break;
            case DamageType.Resistance:
                DealDamage(1);
                break;
            default:
                break;
        }
    }
    public void PrepareDamage(DamageType specialDamageType, int damage)
    {
        if (specialDamageType == DamageType.Special)
        {
            DealDamage(damage);
        }
        else
        {
            PrepareDamage(specialDamageType);
        }
    }
    //public void PrepareDamage(DamageType specialDamageType, Action WeakResist)
    //{
    //    if (specialDamageType == DamageType.Special)
    //    {
    //        //Use passed function to determine damage, used for only weakness/resistance effects
    //    }
    //}

    public void DealDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Defeated();
        }
    }
    public void Defeated()
    {

    }
}