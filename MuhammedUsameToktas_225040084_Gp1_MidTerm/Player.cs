using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public HashSet<string> Inventory { get; private set; } = new HashSet<string>();

    public bool HasItem(string item) => Inventory.Contains(item);

    public Player(string name, int strength, int intelligence)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
    }
}