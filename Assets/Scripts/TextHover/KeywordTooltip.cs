using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TMPHoverTooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        if (text == null)
            Debug.LogError("TMPHoverTooltip: TMP_Text is not assigned.");
        if (cam == null)
            Debug.LogError("TMPHoverTooltip: No MainCamera found.");
    }

    void Update()
    {
        if (text == null || cam == null || TooltipSystem.Instance == null)
            return;

        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Raycast from the mouse to see if we hit the TMP object
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform || hit.transform.IsChildOf(transform))
            {
                int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, mousePos, cam);
                if (linkIndex != -1)
                {
                    TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
                    string keyword = linkInfo.GetLinkID();
                    TooltipSystem.Instance.ShowTooltip(keyword);
                    return;
                }
            }
        }

        TooltipSystem.Instance.HideTooltip();
    }
}
