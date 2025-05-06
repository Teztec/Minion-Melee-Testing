using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class PlayerArea : MonoBehaviour, ICardDropArea
{
    [SerializeField] private Vector3 dropScale = new Vector3(0.8f, 0.8f, 1f);
    [SerializeField] private float dropDuration = 0.3f;
    [SerializeField] private float spacing = 1.2f; // Adjust spacing between cards

    private List<HandCardBehavior> droppedCards = new();

    public void OnCardDrop(HandCardBehavior card)
    {
        if (!droppedCards.Contains(card))
            droppedCards.Add(card);

        card.transform.DOScale(dropScale, dropDuration).SetEase(Ease.OutQuad);
        UpdateCardPositions();
        Debug.Log("Card Dropped");
    }

    private void UpdateCardPositions()
    {
        int count = droppedCards.Count;
        float totalWidth = (count - 1) * spacing;
        float startX = transform.position.x - totalWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            Vector3 targetPos = new Vector3(startX + i * spacing, transform.position.y, 0f);
            droppedCards[i].transform.DOMove(targetPos, dropDuration).SetEase(Ease.OutQuad);
        }
    }
}
