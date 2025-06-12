using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "Card/New Deck")]
public class deckConfig : ScriptableObject
{
    public List<CardEntry> cards;
}
