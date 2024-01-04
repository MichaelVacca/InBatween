using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public InputField nameInputField;
    public InputField moneyInputField;
    public Text messageText;

    public void OnJoinButtonClick()
    {
        string playerName = nameInputField.text;
        float playerMoney;

        if (string.IsNullOrWhiteSpace(playerName) || !float.TryParse(moneyInputField.text, out playerMoney))
        {
            messageText.text = "Please enter a valid name and money amount.";
            return;
        }
        Player newPlayer = new Player(playerName, playerMoney);
        messageText.text = $"Welcome {newPlayer.playerName}, you have {newPlayer.Money} money to start.";

    }
}
