using TMPro;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem Instance;

    [SerializeField] private RectTransform tooltip;
    [SerializeField] private TMP_Text tooltipText;
    private Canvas canvas;

    private void Awake()
    {
        Instance = this;
        tooltip.gameObject.SetActive(false);
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if (tooltip.gameObject.activeSelf)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main,
                out pos);
            tooltip.localPosition = pos + new Vector2(10, -10);
        }
    }

    public void ShowTooltip(string content)
    {
        tooltipText.text = content;
        tooltip.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.gameObject.SetActive(false);
    }
}
