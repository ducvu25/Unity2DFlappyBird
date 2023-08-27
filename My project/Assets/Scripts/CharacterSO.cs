using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charector", menuName = "CharectorSO")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] string id;
    [SerializeField] string name;
    [SerializeField] Sprite hub;
    [SerializeField] int price = 50;
    [SerializeField] GameObject charector;
    [SerializeField] float timeSpawn = 5;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name;}
        set { name = value; }
    }
    public Sprite Hub
    {
        get { return hub; }
        set { hub = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    public float TimeSpawn
    {
        get { return timeSpawn; }
        set
        {
            timeSpawn = value;
        }
    }
    public GameObject Charector
    {
        get { return charector; }
        set
        {
            charector = value;
        }
    }
}
