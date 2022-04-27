using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotcountChage(int val);     // 대리자 정의
    public OnSlotcountChage onSlotCountChange;          // 대리자 인스턴스

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    private ItemDB theDB;
    private ItemTest Item;
    public List<Item> items = new List<Item>();        // 획득 아이템 담을 리스트

    private int slotCnt;        // 슬롯갯수
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    void Start()
    {
        slotCnt = 4;        // 초기화
    }


    public bool AddItem(Item _item)
    {
        if (items.Count < SlotCnt)
        {
            items.Add(_item);
            if (onChangeItem != null)
                onChangeItem.Invoke();      // 아이템 추가에 성공하면 호출
            return true;
        }
        return false;
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);     // 인덱스에 맞는 아이템 속성 제거
        onChangeItem.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if (AddItem(Item.GetItem()))
            {
                Item.DestroyItem();
            }
            //FieldItems fieldItem = collision.GetComponent<FieldItems>();
            //if (AddItem(fieldItem.GetItem()))
            //{
            //    fieldItem.DestroyItem();
            //}
        }
    }
}
