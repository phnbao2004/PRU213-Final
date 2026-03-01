using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFarmControler : MonoBehaviour
{
    public Tilemap tm_Ground;
    public Tilemap tm_Grass;
    public Tilemap tm_Forest;

    public TileBase tb_Ground;
    public TileBase tb_Glass;
    public TileBase tb_Forest;

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

            if (currentTileBase == tb_Glass)
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
    }
}
