using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class DeckViewTester : MonoBehaviour
{
    public List<CardDataTest> cardstoView;
    public GameObject CardViewPrefab;
    public Transform parentContainer;

    private void Start()
    {
        foreach (var card in cardstoView)
        {
            GameObject newCard = Instantiate(CardViewPrefab, parentContainer);
            CardDataViewer view = newCard.GetComponent<CardDataViewer>();
            view.setup(card);
        }
    }
}
