using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Drop Table", menuName = "Game Prog 1/Item Drop table")]
public class ItemDropTable : ScriptableObject
{
    public Item[] itemList;

    public Item GetRandomItem()
    {

    }
}

[Serializable]
public class Item
{
    public string Name;
    public ItemType Type;
    public Sprite ItemIcon;
    public int dropRate;
}

public enum ItemType
{
    Potion,
    Sword,
    Rock    
}
[Serializable]

{

}