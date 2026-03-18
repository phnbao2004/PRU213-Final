using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFarmControler : MonoBehaviour
{
    public Tilemap tm_Ground;
    public Tilemap tm_Grass;
    public Tilemap tm_Forest;

    public TileBase tb_Ground;
    public TileBase tb_Grass;
    public TileBase tb_Forest;

    // SỬA LỖI: Đồng nhất tên biến
    private RecyclableInventoryManager inventoryManager;

    private void Start()
    {
        // SỬA LỖI: Sử dụng đúng tên biến inventoryManager đã khai báo ở trên
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<RecyclableInventoryManager>();
    }
    
    void Update()
    {
        HandleFarmAction();
    }

    public void HandleFarmAction()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3Int cellPos = tm_Ground.WorldToCell(transform.position);
            Debug.Log("Cell Position: " + cellPos);

            TileBase currentTileBase = tm_Grass.GetTile(cellPos);

            if (currentTileBase == tb_Grass)
            {
                tm_Grass.SetTile(cellPos, null);
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3Int cellPos = tm_Ground.WorldToCell(transform.position);
            Debug.Log("Cell Position: " + cellPos);

            TileBase currentTileBase = tm_Grass.GetTile(cellPos);

            if (currentTileBase == null)
            {
                tm_Forest.SetTile(cellPos, tb_Forest);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            Vector3Int cellPos = tm_Ground.WorldToCell(transform.position);
            Debug.Log("Cell pos: " + cellPos);
            TileBase currTileBase = tm_Forest.GetTile(cellPos);

            if (currTileBase != null)
            {
                tm_Grass.SetTile(cellPos, tb_Grass);
                tm_Forest.SetTile(cellPos, null);

                // THÊM TÍNH NĂNG: Tạo và đẩy vật phẩm vào Inventory
                InvenItems itemFlower = new InvenItems();
                itemFlower.name = "Flower";
                itemFlower.description = "A beautiful flower.";

                // Kiểm tra an toàn xem inventoryManager có tồn tại không rồi mới thêm
                if (inventoryManager != null)
                {
                    inventoryManager.AddInventoryItem(itemFlower);
                    Debug.Log("Đã thu hoạch và thêm vào túi đồ: " + itemFlower.name);
                }
                else
                {
                    Debug.LogWarning("Không tìm thấy InventoryManager, vật phẩm chưa được thêm vào túi!");
                }
            }
        }
    }
}