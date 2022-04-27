using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB instance;
    public GameObject ItemPrefab;
    public Vector3[] pos;

    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(ItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<ItemTest>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}



