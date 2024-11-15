using UnityEngine;

public class Geometry
{
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = -3.5f + 1.0f * gridPoint.x;
        float z = -3.5f + 1.0f * gridPoint.y;
        return new Vector3(x, 0, z);
    }

    static public Vector3 BlockPointFromGrid(Vector2Int gridPoint) // same as PointFromGrid but for interacting with blocks
    {
        float x = -3.5f + 1.0f * gridPoint.x;
        float z = -3.5f + 1.0f * gridPoint.y;
        return new Vector3(x, 0.3f, z); // 0.3 is height of the tile plus half height of the block so that block would appear on the tile rather then clip in it
    }

    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    static public Vector2Int GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(4.0f + point.x);
        int row = Mathf.FloorToInt(4.0f + point.z);
        return new Vector2Int(col, row);
    }
}