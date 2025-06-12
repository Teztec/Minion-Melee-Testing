using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

[System.Serializable]
public abstract class Player
{
    public int health;
    public int armor;
    public List<CardInstance> hand = new();
    public List<CardInstance> deck = new();
    public List<CardInstance> discard = new();

    public int reactions;

    public int maxHealth;
    public int maxHandsize;
    public int drawAmount;

    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    public void damaged(int amount)
    {
        if (armor > 0)
        {
            armor -= amount;
        }
        else
        {
            health -= amount;
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }
    public void AddArmor(int amount)
    {
        armor += amount;
        // Clamp or stack armor depending on your game rules
    }
    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(i, deck.Count);
            (deck[i], deck[randomIndex]) = (deck[randomIndex], deck[i]);
        }
    }

    //public void addCards(deckConfig newDeck)
    //{
    //    foreach (var card in newDeck.cards)
    //    {
    //        for(int i = 0; i < card.cardCopies; i++)
    //        {
    //            //deck.Add(new CardInstance(card.cardData));
    //        }
    //    }
    //}
}
