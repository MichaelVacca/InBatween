using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;

public class Player 
{
    public String playerName { get; private set; }
    public float Money { get; private set; }

    public Player(String name, float startingMoney)
    {
        playerName = name;
        Money = startingMoney;
    }
    public void SetName(string newName)
    {
        playerName = newName;
    }

    public void AddMoney(float amount)
    {
        Money += amount;
    }
}
