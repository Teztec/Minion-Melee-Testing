using DG.Tweening;
using UnityEngine;
public class CardGO : MonoBehaviour
{
    private bool isFlipped = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Flip();
    }

    private void Flip()
    {
        isFlipped = !isFlipped;
        transform.DORotate(new(0, isFlipped ? 0f : 180f, 0), 0.25f);
    }
}
