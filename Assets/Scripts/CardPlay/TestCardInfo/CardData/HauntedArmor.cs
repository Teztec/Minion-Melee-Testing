using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HauntedArmor : Delvers
{
    public int SpiritTokens;
    public int maxArmor = 4;

    public HauntedArmor()
    {
        SpiritTokens = 0;

        
    }
    public override void updatePower()
    {
        armor = Mathf.Clamp(SpiritTokens, 0, maxArmor);
    }
    public override void usePower()
    {
        throw new System.NotImplementedException();
    }
}
