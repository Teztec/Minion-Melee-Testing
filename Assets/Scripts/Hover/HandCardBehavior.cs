using UnityEngine;
using DG.Tweening;

public class HandCardBehavior : MonoBehaviour
{
    public CardData cardData;
    private bool isMouseDown = false;
    private Collider2D col;
    private Vector3 startDragPosition;
    private Quaternion originalRotation;
    private bool isFlipped = false;
    public void Init(CardData cardData)
    {
        this.cardData = cardData;
    }

    private void OnMouseEnter()
    {
        if (cardData == null || HandManager.IsDraggingCard) return;
        Vector3 hoverPosition = transform.position + Vector3.up * 3f;
        CardHoverSystem.Instance.Show(cardData, hoverPosition);

    }
    private void OnMouseExit()
    {
        if (HandManager.IsDraggingCard) return;
        CardHoverSystem.Instance.Hide();

    }
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        HandManager.IsDraggingCard = true;
        CardHoverSystem.Instance.Hide();
        startDragPosition = transform.position;
        transform.position = GetMousePositionInWorldSpace();
        originalRotation = transform.rotation;
        transform.rotation = Quaternion.identity;
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }
    private void OnMouseUp()
    {
        HandManager.IsDraggingCard = false;
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
        {
            cardDropArea.OnCardDrop(this);
            HandManager.Instance.PlayCardFromHand(this);
        }
        else
        {
            transform.DOMove(startDragPosition, 0.3f).SetEase(Ease.OutQuad);
            transform.DORotateQuaternion(originalRotation, 0.3f);
        }
    }
    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
    private void Flip()
    {
        isFlipped = !isFlipped;
        transform.DORotate(new(0, isFlipped ? 0f : 180f, 0), 0.25f);
    }

}
