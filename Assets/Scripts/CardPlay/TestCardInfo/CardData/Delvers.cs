using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class Delvers : Player
{
    [SerializeField]
    List<CardDataTest> cardInstance = new List<CardDataTest>();

    public Delvers()
    {
        maxHealth = 20;
        health = maxHealth;
        maxHandsize = 5;

        reactions = 1;

        drawAmount = 1;

        
        

        
    }
    public abstract void updatePower();
    public abstract void usePower();
}
