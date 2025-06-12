using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardData", menuName = "Card/CardData")]
public class CardDataTest : ScriptableObject
{
    public string cardName;
    [TextArea] public string description;
    public Sprite artwork;
    public CardColor Color;
    public CardType cardType;
    public int[] baseDamage;
    public int speed;
    public TargetType targetType;
    public bool hasReact;
    public int CardAmount;
}
public enum CardType
{
    Attack,
    Defense,
    Utility
}
public enum TargetType
{
    AllEnemies,
    Choose,
    Closest,
}