using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class Delvers : Player
{
    public Delvers()
    {
        maxHealth = 20;
        health = maxHealth;
        maxHandsize = 5;

        reactions = 1;

        drawAmount = 1;

        //CardInstance cardInstance = new CardInstance()

        
    }
    public abstract void updatePower();
    public abstract void usePower();
}
