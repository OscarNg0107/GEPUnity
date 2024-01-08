using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{

    [Header("Gameplay Variables")]
    public ItemType type;
    public GameObject Mesh;
    public GameObject Mesh_blueprint;

    [Header("UI Variables")]
    public string itemName;
    public bool stackable = true;
    public int MaxStack = 10;
    public int weight = 1;
    public string desciption;
    public Sprite image;
}

public enum ItemType 
{
    Consumable,
    Weapon
}

public enum ActionType 
{

    
}
