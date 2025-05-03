using UnityEngine;

public class CardHoverSystem : MonoBehaviour
{
    public static CardHoverSystem Instance { get; private set; }

    [SerializeField] private GameObject cardViewHoverPrefab;

    private CardViewHover hoverInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            GameObject obj = Instantiate(cardViewHoverPrefab);
            hoverInstance = obj.GetComponent<CardViewHover>();
            obj.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(CardData card, Vector3 position)
    {
        hoverInstance.gameObject.SetActive(true); // Make sure it's active before setting up
        hoverInstance.Setup(card); // Set up the sprite
        hoverInstance.transform.position = position; // Position it correctly
    }

    public void Hide()
    {
        if (hoverInstance != null)
            hoverInstance.gameObject.SetActive(false);
    }
}

