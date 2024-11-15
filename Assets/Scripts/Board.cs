using UnityEngine;

public class Board : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;

    public GameObject AddBlock(GameObject block, int col, int row)
    {
        Vector2Int gridPoint = Geometry.GridPoint(col, row);
        GameObject newBlock = Instantiate(block, Geometry.BlockPointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
        return newBlock;
    }

    public void RemoveBlock(GameObject block)
    {
        Destroy(block);
    }

    public void MoveBlock(GameObject block, Vector2Int gridPoint)
    {
        block.transform.position = Geometry.BlockPointFromGrid(gridPoint);
    }

    public void SelectBlock(GameObject block)
    {
        MeshRenderer renderers = block.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
    }

    public void DeselectBlock(GameObject block)
    {
        MeshRenderer renderers = block.GetComponentInChildren<MeshRenderer>();
        renderers.material = defaultMaterial;
    }
}