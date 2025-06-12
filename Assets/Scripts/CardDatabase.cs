using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CardDataLoader : MonoBehaviour
{
    public event System.Action OnDeckLoaded;
    public static CardDataLoader Instance { get; private set; }
    public string SelectCharacter { get; private set; }
    public string SelectTeam { get; private set; }
    public int MaxHandSize { get; private set; }

    public List<CardData> deck = new(); // Cached loaded card data
    [SerializeField] private Sprite[] cardSprites; // Add this so you can assign sprites in inspector
    [SerializeField] private List<CardDataTest> delverCards;
    [SerializeField] private List<CardDataTest> hauntedDeck;

    private string url = "https://script.google.com/macros/s/AKfycbwOEcN289EjJpxL-GQhwyAFRZh-qb9xd7yiGlpIjOBcqs3WWUMfrXwu0gcwMqkiRJy-/exec";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T)) StartCoroutine(LoadCharacterDeck());
    //}
    public void SelectedCharacter(GameObject button)
    {
        //string teamName = button.name;
        //SelectedTeam = teamName; // ← this was the bug!

        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        SelectCharacter = text.text.Trim();
        //StartCoroutine(LoadCharacterDeck());
    }
    public void SelectedTeam(GameObject button)
    {
        //string teamName = button.name;
        //SelectedTeam = teamName; // ← this was the bug!

        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        SelectTeam = text.text.Trim();
        
    }
    private void ShuffleDeck(List<CardData> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(i, deck.Count);
            (deck[i], deck[randomIndex]) = (deck[randomIndex], deck[i]);
        }
    }

    private List<CardInstance> BuildDeck(List<CardDataTest> cardDataList)
    {
        var deck = new List<CardInstance>();

        foreach (var card in cardDataList)
        {
            for (int i = 0; i < card.CardAmount; i++)
            {
                deck.Add(new CardInstance(card));
            }

        }
        return deck;
    }
    //private IEnumerator LoadCardData()
    //{
    //    UnityWebRequest request = UnityWebRequest.Get(url);
    //    yield return request.SendWebRequest();

    //    if (request.result == UnityWebRequest.Result.Success)
    //    {
    //        CardDataList cardList = JsonUtility.FromJson<CardDataList>(request.downloadHandler.text);

    //        if (cardList == null)
    //        {
    //            Debug.LogError("Failed to parse CardDataList! Check JSON format.");
    //            yield break;
    //        }

    //        loadedCards.Clear(); // Clear old data

    //        for (int i = 0; i < cardList.cards.Length; i++)
    //        {
    //            var card = cardList.cards[i];

    //            // Safely assign sprite if available
    //            if (i < cardSprites.Length)
    //            {
    //                card.cardSprite = cardSprites[i];
    //            }
    //            else
    //            {
    //                Debug.LogWarning($"Not enough sprites! Card {card.cardName} has no sprite assigned.");
    //            }

    //            loadedCards.Add(card); // Cache the card
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Failed to load data: " + request.error);
    //    }
    //}
    //private IEnumerator LoadCharacterDeck()
    //{
    //    List<(int start, int end)> deckRanges = new();
    //    Debug.Log(SelectTeam);
    //    switch (SelectTeam) //Adds common cards for side
    //    {
    //        case "Monsters":
    //            MaxHandSize = 8;
    //            deckRanges.Add((0, 15));
    //            break;
    //        case "Delvers":
    //            MaxHandSize = 5;
    //            deckRanges.Add((15, 25));
    //            break;
    //    }
    //    switch (SelectCharacter)
    //    {
    //        case "Dragon":
    //            deckRanges.Add((85, 110));
    //            break;
    //        case "Alchemist":
    //            deckRanges.Add((25, 40));
    //            break;
    //        case "Elemental":
    //            deckRanges.Add((40, 55));
    //            break;
    //        case "Spawn":
    //            deckRanges.Add((70, 85));
    //            break;
    //        case "Haunted Armor":
    //            deckRanges.Add((55, 70));
    //            break;
    //    }

    //    deck.Clear(); // Important to clear old cards
    //    foreach (var range in deckRanges)
    //    {
    //        yield return LoadDeck(range.start, range.end);
    //    }

    //    ShuffleDeck(deck);
    //    Debug.Log("Deck loaded and shuffled: " + deck.Count + " cards");
    //    OnDeckLoaded?.Invoke();
    //}


    //private IEnumerator LoadDeck(int start, int end)
    //{
    //    UnityWebRequest request = UnityWebRequest.Get(url);
    //    yield return request.SendWebRequest();

    //    if (request.result == UnityWebRequest.Result.Success)
    //    {
    //        CardDataList cardList = JsonUtility.FromJson<CardDataList>(request.downloadHandler.text);

    //        if (cardList == null)
    //        {
    //            Debug.LogError("Failed to parse CardDataList! Check JSON format.");
    //            yield break;
    //        }

    //        for (int i = start; i < end; i++)
    //        {
    //            var card = cardList.cards[i];

    //            // Safely assign sprite if available
    //            if (i < cardSprites.Length)
    //            {
    //                card.cardSprite = cardSprites[i];
    //            }
    //            else
    //            {
    //                Debug.LogWarning($"Not enough sprites! Card {card.cardName} has no sprite assigned.");
    //            }

    //            deck.Add(card); // Cache the card
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Failed to load data: " + request.error);
    //    }
    //}
}
