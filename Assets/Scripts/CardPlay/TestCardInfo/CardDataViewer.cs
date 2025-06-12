using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

//[ExecuteInEditMode]
public class CardDataViewer : MonoBehaviour
{
    public CardDataTest card;

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text speedText;

    public Image art;
    public Image banner;
    public Image cardTypeArt;

    [SerializeField] public Sprite[] cardTypeSprites;
    public void setup(CardDataTest cardView)
    {
        card = cardView;
        nameText.text = card.name;
        speedText.text = card.speed.ToString();

        art.sprite = card.artwork;
        banner.color = card.Color.CardDeckColor;

        descriptionText.text = card.description;

        setCardType();
        updateDescription();
    }

    public void updateDescription()
    {

        if (card.baseDamage.Length < 1) return;

        for (int i = 0; i < card.baseDamage.Length; i++)
        {
            descriptionText.text = card.description.Replace($"[X{i}]", card.baseDamage[i].ToString());
        }
    }

    public void setCardType()
    {
        switch (card.cardType)
        {
            case CardType.Attack:
                cardTypeArt.sprite = cardTypeSprites[0];
                break;
            case CardType.Defense:
                cardTypeArt.sprite = cardTypeSprites[1];
                break;
            case CardType.Utility:
                cardTypeArt.sprite = cardTypeSprites[2];
                break;
        }
    }
}
