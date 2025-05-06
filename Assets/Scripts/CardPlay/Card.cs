//using DG.Tweening;
//using UnityEngine;
//public class Card : MonoBehaviour
//{
//    private Collider2D col;
//    private Vector3 startDragPosition;
//    private bool isFlipped = false;
//    private void Start()
//    {
//        col = GetComponent<Collider2D>();
//    }
//    private void OnMouseDown()
//    {
//        startDragPosition = transform.position;
//        transform.position = GetMousePositionInWorldSpace();
//    }
//    private void OnMouseDrag()
//    {
//        transform.position = GetMousePositionInWorldSpace();
//    }
//    private void OnMouseUp()
//    {
//        col.enabled = false;
//        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
//        col.enabled = true;
//        if (hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
//        {
//            cardDropArea.OnCardDrop(this);
//        }
//        else
//        {
//            transform.DOMove(startDragPosition, 0.3f).SetEase(Ease.OutQuad);
//        }
//    }
//    public Vector3 GetMousePositionInWorldSpace()
//    {
//        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        p.z = 0f;
//        return p;
//    }
//    private void Flip()
//    {
//        isFlipped = !isFlipped;
//        transform.DORotate(new(0, isFlipped ? 0f : 180f, 0), 0.25f);
//    }

//}
