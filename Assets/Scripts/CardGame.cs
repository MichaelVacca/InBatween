using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGame : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardParent; 
    public Sprite[] cardSprites;
    public float cardSpacing = 1.5f;
    private List<GameObject> displayedCards = new List<GameObject>();
    private Dictionary<string, int> cardValues = new Dictionary<string, int>();

    private int firstCardValue = -1;
    private int secondCardValue = -1;





    void Start()
    {
        InitializeCardValues();
        DisplayStartingCards();
    }

    void DisplayStartingCards()
    {
        DisplayRandomCard();
        firstCardValue = cardValues[displayedCards[0].GetComponent<SpriteRenderer>().sprite.name];

        DisplayRandomCard();
        secondCardValue = cardValues[displayedCards[1].GetComponent<SpriteRenderer>().sprite.name];
    }

    void InitializeCardValues()
    {


            // hearts
            cardValues["CardDeck_7x100_0"] = 2;   
            cardValues["CardDeck_7x100_1"] = 3;   
            cardValues["CardDeck_7x100_2"] = 4;   
            cardValues["CardDeck_7x100_3"] = 5;   
            cardValues["CardDeck_7x100_4"] = 6;   
            cardValues["CardDeck_7x100_5"] = 7;   
            cardValues["CardDeck_7x100_6"] = 8;   
            cardValues["CardDeck_7x100_7"] = 9;   
            cardValues["CardDeck_7x100_8"] = 10;  
            cardValues["CardDeck_7x100_9"] = 11;  
            cardValues["CardDeck_7x100_10"] = 12; 
            cardValues["CardDeck_7x100_11"] = 13; 
            cardValues["CardDeck_7x100_12"] = 1;  //ace

            // diamonds
            cardValues["CardDeck_7x100_13"] = 2;
            cardValues["CardDeck_7x100_14"] = 3;
            cardValues["CardDeck_7x100_15"] = 4;
            cardValues["CardDeck_7x100_16"] = 5;
            cardValues["CardDeck_7x100_17"] = 6;
            cardValues["CardDeck_7x100_18"] = 7;
            cardValues["CardDeck_7x100_19"] = 8;
            cardValues["CardDeck_7x100_20"] = 9;
            cardValues["CardDeck_7x100_21"] = 10;
            cardValues["CardDeck_7x100_22"] = 11;
            cardValues["CardDeck_7x100_23"] = 12;
            cardValues["CardDeck_7x100_24"] = 13;
            cardValues["CardDeck_7x100_25"] = 1;//ace



            // clubs
            cardValues["CardDeck_7x100_26"] = 2;
            cardValues["CardDeck_7x100_27"] = 3;
            cardValues["CardDeck_7x100_28"] = 4;
            cardValues["CardDeck_7x100_29"] = 5;
            cardValues["CardDeck_7x100_30"] = 6;
            cardValues["CardDeck_7x100_31"] = 7;
            cardValues["CardDeck_7x100_32"] = 8;
            cardValues["CardDeck_7x100_33"] = 9;
            cardValues["CardDeck_7x100_34"] = 10;
            cardValues["CardDeck_7x100_35"] = 11;
            cardValues["CardDeck_7x100_36"] = 12;
            cardValues["CardDeck_7x100_37"] = 13;
            cardValues["CardDeck_7x100_38"] = 1;//ace



            // spades
            cardValues["CardDeck_7x100_39"] = 2;
            cardValues["CardDeck_7x100_40"] = 3;
            cardValues["CardDeck_7x100_41"] = 4;
            cardValues["CardDeck_7x100_42"] = 5;
            cardValues["CardDeck_7x100_43"] = 6;
            cardValues["CardDeck_7x100_44"] = 7;
            cardValues["CardDeck_7x100_45"] = 8;
            cardValues["CardDeck_7x100_46"] = 9;
            cardValues["CardDeck_7x100_47"] = 10;
            cardValues["CardDeck_7x100_48"] = 11;
            cardValues["CardDeck_7x100_49"] = 12;
            cardValues["CardDeck_7x100_50"] = 13;
            cardValues["CardDeck_7x100_51"] = 1;

    }


    void DisplayRandomCard()
    {
        if (cardSprites.Length > 0)
        {
            // Randomly choose a card to display
            int randomIndex = Random.Range(0, cardSprites.Length);
            Sprite cardSprite = cardSprites[randomIndex];

            // Instantiate a new card GameObject
            GameObject newCard = Instantiate(cardPrefab, cardParent);
            newCard.GetComponent<SpriteRenderer>().sprite = cardSprite;

            // Position the new card based on the number of displayed cards
            newCard.transform.localPosition = new Vector3(displayedCards.Count * cardSpacing, 0, 0);

            // Add the new card to the list of displayed cards
            displayedCards.Add(newCard);
        }
        else
        {
            Debug.LogError("The cardSprites array is empty. Make sure sprites are assigned in the editor.");
        }
    }



    public void OnHitButton()
    {
        if (displayedCards.Count == 2)
        {
            DisplayRandomCard();

            // Obtain the sprite name for the third card
            string thirdCardKey = displayedCards[2].GetComponent<SpriteRenderer>().sprite.name;
            Debug.Log("Third card sprite name: " + thirdCardKey);

            // Use TryGetValue to avoid KeyNotFoundException
            if (cardValues.TryGetValue(thirdCardKey, out int thirdCardValue))
            {
                CheckIfThirdCardIsInBetween(thirdCardValue);
            }
            else
            {
                Debug.LogError("Third card key not found in dictionary: " + thirdCardKey);
            }
        }
    }

    void CheckIfThirdCardIsInBetween(int thirdCardValue)
    {
        int lowerValue = Mathf.Min(firstCardValue, secondCardValue);
        int higherValue = Mathf.Max(firstCardValue, secondCardValue);

        if (thirdCardValue > lowerValue && thirdCardValue < higherValue)
        {
            Debug.Log("The third card is in between.");
            // Implement what happens if the card is in between
        }
        else
        {
            Debug.Log("The third card is not in between.");
            // Implement what happens if the card is not in between
        }
    }

    void CheckIfThirdCardIsInBetween()
    {
        string firstCardKey = displayedCards[0].GetComponent<SpriteRenderer>().sprite.name;
        string secondCardKey = displayedCards[1].GetComponent<SpriteRenderer>().sprite.name;
        string thirdCardKey = displayedCards[2].GetComponent<SpriteRenderer>().sprite.name;

        if (cardValues.TryGetValue(firstCardKey, out int firstCardValue) &&
            cardValues.TryGetValue(secondCardKey, out int secondCardValue) &&
            cardValues.TryGetValue(thirdCardKey, out int thirdCardValue))
        {
            // Log the values of the cards
            Debug.Log("First Card Value: " + firstCardValue);
            Debug.Log("Second Card Value: " + secondCardValue);
            Debug.Log("Third Card Value: " + thirdCardValue);

            // Sort the first two card values
            int lowerValue = Mathf.Min(firstCardValue, secondCardValue);
            int higherValue = Mathf.Max(firstCardValue, secondCardValue);

            // Check if the third card's value is in between the first two
            if (thirdCardValue > lowerValue && thirdCardValue < higherValue)
            {
                Debug.Log("The third card is in between.");
                // Implement what happens if the card is in between
            }
            else
            {
                Debug.Log("The third card is not in between.");
                // Implement what happens if the card is not in between
            }
        }
        else
        {
            Debug.LogError("One of the keys does not exist in the cardValues dictionary.");
            // Optionally, output the keys that failed
            if (!cardValues.ContainsKey(firstCardKey))
            {
                Debug.LogError("First card key not found in dictionary: " + firstCardKey);
            }
            if (!cardValues.ContainsKey(secondCardKey))
            {
                Debug.LogError("Second card key not found in dictionary: " + secondCardKey);
            }
            if (!cardValues.ContainsKey(thirdCardKey))
            {
                Debug.LogError("Third card key not found in dictionary: " + thirdCardKey);
            }
        }
    }



    public void OnSkipButton()
    {
        // Remove all displayed cards from the scene
        foreach (GameObject card in displayedCards)
        {
            Destroy(card);
        }
        displayedCards.Clear(); // Clear the list of displayed cards

        // Display two new random cards
        DisplayRandomCard();
        DisplayRandomCard();
    }
}


