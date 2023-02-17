using UnityEngine;
using LegendsOfAsaseEnums;

public class Health : MonoBehaviour
{
    public Legend owner;
    public int currentHealth = 5;
    public int maximumHealth = 5;

    public void InitializeHealth(Legend legend)
    {
        SetOwner(legend);
        maximumHealth = 5;
        currentHealth = maximumHealth;
    }

    public void SetOwner(Legend legend)
    {
        owner = legend;
    }

    public bool AtFullHealth()
    {
        if (currentHealth == maximumHealth)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines the exact amount of damage to do, based off of shield mods, DamageType passed, and starting value
    /// </summary>
    /// <param name="damageType">Check for weaknesses, resistance, both or specific one will happen before this method</param>
    /// <param name="startingDamage">Pass 0, if no mods on attacking legend</param>
    public void PrepareDamage(DamageType damageType, int startingDamage)
    {
        int damageAmount = startingDamage;

        //Special DamageType does the exact amount of damage passed after Shields, so skip to shield checking
        if (damageType != DamageType.Special)
        {
            switch (damageType)
            {
                case DamageType.Standard:
                    damageAmount += 2;
                    break;
                case DamageType.Weakness:
                    damageAmount += 4;
                    break;
                case DamageType.Resistance:
                    damageAmount += 1;
                    break;
                default:
                    break;
            }
        }

        //check for owner's shield mods
        DealDamage(damageAmount);
    }

    private void DealDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{owner.GetShortName()} took {amount} damage.");


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Defeated();
        }
    }
    public void Defeated()
    {
        Debug.Log($"{owner.GetShortName()} has been defeated.");
        //owner.Die();
    }
}