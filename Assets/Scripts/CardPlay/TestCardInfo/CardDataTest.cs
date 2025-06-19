using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

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
    private bool hasReact => reactionEffects.Count > 0 && reactionEffects != null;
    public int CardAmount;

    public List<CardEffect> baseEffects;
    public List<CardEffect> reactionEffects;


    [System.Serializable]
    [IncludeInSettings(true)]
    public class CardEffect
    {
        [SerializeField] public int amount;
        [SerializeField] public TargetType TargetType;
        [SerializeField] public EffectType effecttype;

    }

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
public enum EffectType
{
    Heal,
    GainArmor,
    damageBuff,
    speedChange,
    drawCard
}