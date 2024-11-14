using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector2Int[] RookDirections = {new Vector2Int(0,1), new Vector2Int(1, 0),
        new Vector2Int(0, -1), new Vector2Int(-1, 0)};
    public Vector2Int[] BishopDirections = {new Vector2Int(1,1), new Vector2Int(1, -1),
        new Vector2Int(-1, -1), new Vector2Int(-1, 1)};

    public List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        List<Vector2Int> directions = new List<Vector2Int>(BishopDirections);
        directions.AddRange(RookDirections);

        foreach (Vector2Int dir in directions)
        {
            Vector2Int nextGridPoint = new Vector2Int(gridPoint.x + dir.x, gridPoint.y + dir.y);
            locations.Add(nextGridPoint);
        }

        return locations;
    }
}
