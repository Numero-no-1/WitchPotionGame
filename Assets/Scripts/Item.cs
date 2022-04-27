using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip,
    Use,
    Quest
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;


    public bool Use()           // 아이템 사용여부 확인
    {
        // 아이템 사용
        bool isUsed = false;
        foreach (ItemEffect eft in efts)    // 반복문 돌려서 efts의 ExecuteRole 실행
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed;
    }
}


