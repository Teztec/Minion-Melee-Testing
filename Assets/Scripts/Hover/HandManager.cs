using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    [SerializeField] private int maxHandSize;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnPoint;
    private List<GameObject> handCards = new();
    //private List<CardData> allCardData = new(); // List to store card data
    private List<CardData> shuffledDeck = new();
    private bool isDeckLoading = true;
    public static HandManager Instance { get; private set; }
    public static bool IsDraggingCard { get; set; } = false;

    private void Start()
    {
        CardDataLoader.Instance.OnDeckLoaded += OnDeckReady;

        //Debug.Log("Loaded cards: " + allCardData.Count);
        //shuffledDeck = new List<CardData>(allCardData);
        //ShuffleDeck(shuffledDeck);

    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void OnDeckReady()
    {
        shuffledDeck = CardDataLoader.Instance.deck;
        maxHandSize = CardDataLoader.Instance.MaxHandSize;
        for (int i = 0; i < maxHandSize; i++)
        {
            DrawCard();
        }
        isDeckLoading = false;
        Debug.Log("Deck finished loading");
    }
    private void Update()
    {
        if (isDeckLoading) return;
        
        if (Input.GetKeyDown(KeyCode.Space)) DrawCard();
    }
    

    private void DrawCard()
    {
        if (handCards.Count >= maxHandSize) {
            Debug.Log("Hand Full");
            return;
        }
        if (shuffledDeck.Count == 0)
        {
            Debug.Log("No cards in deck");
            return;
        }

        CardData cardData = shuffledDeck[0];
        shuffledDeck.RemoveAt(0);
        //CardData cardData = allCardData[Random.Range(0, allCardData.Count)];
        CreateCard(cardData);
    }

    private void CreateCard(CardData cardData)
    {
        if (handCards.Count >= maxHandSize) return;

        GameObject g = Instantiate(cardPrefab, spawnPoint.position, spawnPoint.rotation);
        HandCardBehavior behavior = g.GetComponent<HandCardBehavior>();

        if (behavior != null)
        {
            behavior.Init(cardData); // <-- THIS is crucial!
        }

        SpriteRenderer sr = g.GetComponentInChildren<SpriteRenderer>();
        if (sr != null && cardData.cardSprite != null)
        {
            sr.sprite = cardData.cardSprite;
        }
        else
        {
            Debug.LogWarning($"Missing sprite on card {cardData.cardName}");
        }

        // Sorting order
        SpriteRenderer cardSprite = g.GetComponentInChildren<SpriteRenderer>();
        if (cardSprite != null)
        {
            cardSprite.sortingOrder = handCards.Count;
        }

        handCards.Add(g);
        UpdateCardPositions();
    }

    private void UpdateCardPositions()
    {
        if (handCards.Count == 0) return;

        float cardSpacing = 1f / maxHandSize;
        float firstCardPosition = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < handCards.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            handCards[i].transform.DOMove(splinePosition, 0.25f);
            handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }

    public void PlayCardFromHand(HandCardBehavior cardBehavior)
    {
        if (handCards.Contains(cardBehavior.gameObject))
        {
            // Temporarily ignore calling TimelineManager by just logging the action
            Debug.Log($"Card played: {cardBehavior.cardData.cardName}");

            // Remove card from hand
            handCards.Remove(cardBehavior.gameObject);

            UpdateCardPositions();
        }
    }

}
