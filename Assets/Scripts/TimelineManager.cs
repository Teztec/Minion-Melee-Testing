//using UnityEngine;
//using Unity.Netcode;
//using System.Collections.Generic;
//using System.Collections;
//using TMPro;

//public class TimelineManager : NetworkBehaviour
//{
//    public static TimelineManager Instance;

//    public Transform timelinePanel;
//    public GameObject faceDownPrefab;
//    public GameObject faceUpPrefab;

//    private List<TimelineCard> playedCards = new();

//    private void Awake()
//    {
//        Instance = this;
//    }

//    [ServerRpc(RequireOwnership = false)]
//    public void PlayerPlaysCardServerRpc(string cardName, int speed, int damage, int cardType, ServerRpcParams rpcParams = default)
//    {
//        ulong playerId = rpcParams.Receive.SenderClientId;

//        CardData newCard = new CardData()
//        {
//            cardName = cardName,
//            speed = 1,
//            damage = damage,
//            cardType = (CardType)cardType
//        };

//        playedCards.Add(new TimelineCard
//        {
//            ownerId = playerId,
//            cardData = newCard,
//            isFaceUp = false
//        });

//        UpdateTimelineVisualClientRpc(false);

//        if (playedCards.Count == NetworkManager.Singleton.ConnectedClients.Count)
//        {
//            RevealTimeline();
//        }
//    }

//    [ClientRpc]
//    private void UpdateTimelineVisualClientRpc(bool reveal)
//    {
//        foreach (Transform child in timelinePanel)
//        {
//            Destroy(child.gameObject);
//        }

//        foreach (var tCard in playedCards)
//        {
//            GameObject cardObj = Instantiate(reveal ? faceUpPrefab : faceDownPrefab, timelinePanel);
//            TMP_Text text = cardObj.GetComponentInChildren<TMP_Text>();
//            text.text = reveal ? tCard.cardData.cardName : "??";
//        }
//    }

//    private void RevealTimeline()
//    {
//        playedCards.Sort((a, b) => b.cardData.speed.CompareTo(a.cardData.speed));
//        UpdateTimelineVisualClientRpc(true);
//        StartCoroutine(PlayTimeline());
//    }

//    private IEnumerator PlayTimeline()
//    {
//        foreach (var tCard in playedCards)
//        {
//            Debug.Log($"Playing {tCard.cardData.cardName} from player {tCard.ownerId}");
//            yield return new WaitForSeconds(1f);
//        }

//        playedCards.Clear();
//    }
//}

//public class TimelineCard
//{
//    public ulong ownerId;
//    public CardData cardData;
//    public bool isFaceUp;
//}