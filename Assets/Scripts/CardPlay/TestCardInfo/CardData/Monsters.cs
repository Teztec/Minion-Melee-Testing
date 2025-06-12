using System.Collections.Generic;
using UnityEngine;

public abstract class Monsters : Player
{
    
    public Monsters()
    {
        maxHealth = 20;
        health = maxHealth;
        maxHandsize = 5;

        drawAmount = 3;

        //commonCards = new List<CardInstance>();
    }
    public abstract void updatePower();
    public abstract void usePower();
}
