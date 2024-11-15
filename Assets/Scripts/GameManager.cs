using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Board board;
    public GameObject levelBlock;
    private GameObject[,] blocks;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        blocks = new GameObject[7, 7];
        InitialSetup();
    }

    private void InitialSetup()
    {
        AddBlock(levelBlock, 3, 1);
    }

    public void AddBlock(GameObject prefab, int col, int row)
    {
        GameObject blockObject = board.AddBlock(prefab, col, row);
        blocks[col, row] = blockObject;
    }

    public void SelectBlockAtGrid(Vector2Int gridPoint)
    {
        GameObject selectedBlock = blocks[gridPoint.x, gridPoint.y];
        if (selectedBlock)
        {
            board.SelectBlock(selectedBlock);
        }
    }

    public List<Vector2Int> MovesForBlock(GameObject blockObject)
    {
        Block block = blockObject.GetComponent<Block>();
        Vector2Int gridPoint = GridForBlock(blockObject);
        List<Vector2Int> locations = block.MoveLocations(gridPoint);

        locations.RemoveAll(gp => gp.x < 1 || gp.x > 6 || gp.y < 1 || gp.y > 6 || ((gp.x < 3 || gp.x > 4) && (gp.y < 3 || gp.y > 4)));

        return locations;
    }

    public void Move(GameObject block, Vector2Int gridPoint)
    {
        Block blockComponent = block.GetComponent<Block>();

        Vector2Int startGridPoint = GridForBlock(block);
        blocks[startGridPoint.x, startGridPoint.y] = null;
        blocks[gridPoint.x, gridPoint.y] = block;
        board.MoveBlock(block, gridPoint);
    }

    public void SelectBlock(GameObject block)
    {
        board.SelectBlock(block);
    }

    public void DeselectBlock(GameObject block)
    {
        board.DeselectBlock(block);
    }

    public GameObject BlockAtGrid(Vector2Int gridPoint)
    {
        if (gridPoint.x > 7 || gridPoint.y > 7 || gridPoint.x < 0 || gridPoint.y < 0)
        {
            return null;
        }
        return blocks[gridPoint.x, gridPoint.y];
    }

    public Vector2Int GridForBlock(GameObject block)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (blocks[i, j] == block)
                {
                    return new Vector2Int(i, j);
                }
            }
        }

        return new Vector2Int(-1, -1);
    }
}
