using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardInstance : MonoBehaviour
{
    public CardDataTest baseData;
    public int[] currentDamage;
    public int currentSpeed;
    public List<Buffs> activeBuffs;

    public CardInstance(CardDataTest data)
    {
        baseData = data;
        currentDamage = (int[])data.baseDamage.Clone(); // Make a copy
        currentSpeed = data.speed;
        //activeBuffs = new List<Buffs>(data.buffs);
    }

    public void ApplyBuff(Buffs buff)
    {
        // Modify damage/speed/etc. based on buff logic
        switch (buff.type)
        {
            case BuffType.attackChange:
                for (int i = 0; i < currentDamage.Length; i++)
                {
                    currentDamage[i] += buff.amount;
                }
                break;
            case BuffType.speedChange:
                currentSpeed += buff.amount;
                break;
            case BuffType.armor:
                //getOwner(this).addArmor(buff.amount)
                break;
            case BuffType.heal:
                //getOwner(this).addHealth(buff.amount)
                break;
        }
    }

    public string GetDescriptionWithVariables()
    {
        string desc = baseData.description;

        for (int i = 0; i < currentDamage.Length; i++)
            desc = desc.Replace($"[X{i}]", currentDamage[i].ToString());

        return desc;
    }
}
