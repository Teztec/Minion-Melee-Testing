using UnityEngine;

[System.Serializable]
public class CardData
{
    public string cardName;
    public int speed;
    public int damage;
    public string cardType;
    public Sprite cardSprite;

    public CardData(string cardName, int speed, int damage, string cardType, Sprite cardSprite)
    {
        this.cardName = cardName;
        this.speed = speed;
        this.damage = damage;
        this.cardType = cardType;
        this.cardSprite = cardSprite;

    }
}

[System.Serializable]
public class CardDataList
{
    public CardData[] cards;
}
