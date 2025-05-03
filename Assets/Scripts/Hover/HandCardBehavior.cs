using UnityEngine;
using DG.Tweening;

public class HandCardBehavior : MonoBehaviour
{
    public CardData cardData;
    public void Init(HandManager handManager, CardData cardData)
    {
        this.cardData = cardData;
    }

    private void OnMouseEnter()
    {
        if (cardData == null)
        {
            Debug.LogError("cardData is null in HandCardBehavior.");
            return;
        }

        Vector3 hoverPosition = transform.position + Vector3.up * 3f;
        CardHoverSystem.Instance.Show(cardData, hoverPosition);
    }


    private void OnMouseExit()
    {
        CardHoverSystem.Instance.Hide();
    }
    //public CardData cardData;
    //private Vector3 originalScale;
    //private Vector3 originalPosition;
    //private bool isHovered = false;
    //private SpriteRenderer spriteRenderer;

    //// Sorting order of the card
    //private int originalSortingOrder;

    //public void Init(HandManager handManager, CardData cardData)
    //{
    //    this.cardData = cardData;
    //    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    //    if (spriteRenderer != null)
    //    {
    //        originalSortingOrder = spriteRenderer.sortingOrder;
    //    }
    //}

    //private void Start()
    //{
    //    originalScale = transform.localScale;
    //    originalPosition = transform.localPosition;
    //}

    //private Tween scaleTween;
    //private Tween moveTween;

    //private void OnMouseEnter()
    //{
    //    if (isHovered) return;
    //    isHovered = true;

    //    scaleTween?.Kill();
    //    moveTween?.Kill();

    //    // Scale and move the card forward on hover
    //    scaleTween = transform.DOScale(originalScale * 1.2f, 0.2f);
    //    moveTween = transform.DOLocalMoveZ(originalPosition.z - 0.5f, 0.2f);

    //    // Update sorting order to bring the card to the front when hovered
    //    if (spriteRenderer != null)
    //    {
    //        spriteRenderer.sortingOrder = 99; // Set to a higher value to bring to front
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    if (!isHovered) return;
    //    isHovered = false;

    //    scaleTween?.Kill();
    //    moveTween?.Kill();

    //    // Return to original scale and position when mouse exits
    //    scaleTween = transform.DOScale(originalScale, 0.2f);
    //    moveTween = transform.DOLocalMoveZ(originalPosition.z, 0.2f);

    //    // Restore sorting order
    //    if (spriteRenderer != null)
    //    {
    //        spriteRenderer.sortingOrder = originalSortingOrder; // Restore original sorting order
    //    }
    //}

}
