using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.efts = _item.efts;

    }

    public Item GetItem()
    {
        return item;
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
