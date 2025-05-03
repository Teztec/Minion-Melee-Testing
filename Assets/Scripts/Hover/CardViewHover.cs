using UnityEngine;

public class CardViewHover : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // Try to get the SpriteRenderer component from the current object or its children
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing in CardViewHover prefab.");
        }
    }

    public void Setup(CardData cardData)
    {
        if (cardData == null)
        {
            Debug.LogError("CardData passed to Setup is null.");
            return;
        }

        if (cardData.cardSprite == null)
        {
            Debug.LogError($"Card sprite is null for card: {cardData.cardName}");
            return;
        }

        spriteRenderer.sprite = cardData.cardSprite;
    }

}

