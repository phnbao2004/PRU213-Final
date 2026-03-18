using PolyAndCode.UI;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableInventoryManager : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField]
    private RecyclableScrollRect _recyclableScrollRect;
    [SerializeField]
    private int _dataLength;

    // ĐÃ SỬA: Sửa invetoryGameObject thành inventoryGameObject
    public GameObject inventoryGameObject;

    private List<InvenItems> _invenItems = new List<InvenItems>();

    private void Awake()
    {
        _recyclableScrollRect.DataSource = this;
    }

    public int GetItemCount()
    {
        return _invenItems.Count;
    }

    public void SetCell(ICell cell, int index)
    {
        var item = cell as CellItemData;
        item.ConfigureCell(_invenItems[index], index);
    }

    private void Start()
    {
        List<InvenItems> lstItem = new List<InvenItems>();

        for (int i = 0; i < 50; i++)
        {
            InvenItems invenItem = new InvenItems();
            invenItem.name = "Name_" + i.ToString();
            invenItem.description = "Des_" + i.ToString();

            lstItem.Add(invenItem);
        }

        SetLstItem(lstItem);
        _recyclableScrollRect.ReloadData();
    }

    public void SetLstItem(List<InvenItems> lst)
    {
        _invenItems = lst;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InvenItems invenItemDemo = new InvenItems(name: "Ca", description: "Ca");
            _invenItems.Add(invenItemDemo);
            _recyclableScrollRect.ReloadData();
        }

        if (Input.GetKeyDown(KeyCode.B)) // bag
        {
            //inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
            Vector3 crrPosInven = inventoryGameObject.GetComponent<RectTransform>().anchoredPosition;
            inventoryGameObject.GetComponent<RectTransform>().anchoredPosition = crrPosInven.y == 1000 ? Vector3.zero : new Vector3(0, 1000, 0);
        }
    }
    public void AddInventoryItem(InvenItems item)
    {
        _invenItems.Add(item);
        _recyclableScrollRect.ReloadData();
    }
}