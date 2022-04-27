using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public Item item;
    public Image itemIcon;
    public int slotnum;     // int형 변수 선언

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventDate)
    {
        bool isUse = item.Use();        // Slot에 있는 item.Use메서드 호출
        if (isUse)                      // 아이템 사용에 성공하면 RemoveItem 호출
        {
            Inventory.instance.RemoveItem(slotnum);
        }
    }
}
